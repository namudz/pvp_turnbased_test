using System.Collections.Generic;
using Game;
using Game.ActionsExecutioner;
using Game.Turn;
using Game.Turn.Dealer;
using Game.Turn.Handlers;
using Heroes.Attacks.Bullets;
using Heroes.Controllers;
using Services;
using Services.EventDispatcher;
using Services.Pooling;
using UnityEngine;
using Views;

namespace Installers
{
    public class GameInstaller : MonoBehaviour
    {
        [Header("Game Actions Executioner")]
        [SerializeField] private GameActionsExecutioner _gameActionsExecutioner;
        
        [Header("Heroes Controllers")]
        [SerializeField] private List<HeroController> _player1Heroes;
        [SerializeField] private List<HeroController> _player2Heroes;

        [Header("Views")]
        [SerializeField] private HeroActionsPanelView _heroActionsPanelView;

        [Header("Pools")]
        [SerializeField] private Transform _bulletsPoolParent;
        [SerializeField] private GameObjectPoolDataConfig _bulletPoolConfig;

        private IGame _game;
        private ITurnDealer _turnDealer;
        private ITurnHandler _player1TurnHandler;
        private ITurnHandler _player2TurnHandler;
        private IEventDispatcher _eventDispatcher;
        private int _counterHeroesInstalled;
        private BulletHotDogPool _bulletsPool;

        private void Awake()
        {
            InitializeEventDispatcher();
            InstallTurnDependencies();
            InstallGameDependencies();
            InstallHeroDependencies();
            InstallPools();

            InjectViewDependencies();
        }

        private void Start()
        {
            _game.StartGame();
        }
        
        private void InitializeEventDispatcher()
        {
            _eventDispatcher = new EventDispatcher();
            ServiceLocator.Instance.RegisterService(_eventDispatcher);
        }

        private void InstallTurnDependencies()
        {
            _player1TurnHandler = new TurnHandler(TurnTypes.Turn.Player_1, _player1Heroes);
            _player2TurnHandler = new TurnHandler(TurnTypes.Turn.Player_2, _player2Heroes);
            _turnDealer = new TurnDealer(_player1TurnHandler, _player2TurnHandler, _eventDispatcher);
        }
        
        private void InstallHeroDependencies()
        {
            _counterHeroesInstalled = 0;
            InjectHeroControllerDependencies(_player1Heroes, _player1TurnHandler);
            InjectHeroControllerDependencies(_player2Heroes, _player2TurnHandler);
            _game.SetHeroes(_player1Heroes, _player2Heroes);
        }

        private void InjectHeroControllerDependencies(IEnumerable<HeroController> heroControllers, ITurnHandler turnHandler)
        {
            foreach (var heroController in heroControllers)
            {
                heroController.InjectDependencies(_counterHeroesInstalled, turnHandler, _eventDispatcher, _gameActionsExecutioner);
                ++_counterHeroesInstalled;
            }
        }
        
        private void InstallGameDependencies()
        {
            _game = new GameMain(_turnDealer, _eventDispatcher);
            _gameActionsExecutioner.InjectDependencies(_turnDealer, _eventDispatcher);
        }
        
        private void InstallPools()
        {
            _bulletsPool = new BulletHotDogPool(_bulletPoolConfig.PoolData);
            ServiceLocator.Instance.RegisterService<IGameObjectPool<BulletController>>(_bulletsPool);
            _bulletsPool.InstantiateInitialElements(_bulletsPoolParent);
        }

        private void InjectViewDependencies()
        {
            _heroActionsPanelView.InjectDependencies(_eventDispatcher);
        }

    }
}