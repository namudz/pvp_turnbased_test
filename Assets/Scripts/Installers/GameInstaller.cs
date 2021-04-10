using System.Collections.Generic;
using Game;
using Game.Turn;
using Game.Turn.Dealer;
using Game.Turn.Handlers;
using Heroes.Controllers;
using Services.EventDispatcher;
using UnityEngine;
using Views;

namespace Installers
{
    public class GameInstaller : MonoBehaviour
    {
        [Header("Heroes Controllers")]
        [SerializeField] private List<HeroController> _player1Heroes;
        [SerializeField] private List<HeroController> _player2Heroes;

        [Header("Views")]
        [SerializeField] private HeroActionsPanelView _heroActionsPanelView;

        private IGame _game;
        private ITurnDealer _turnDealer;
        private ITurnHandler _player1TurnHandler;
        private ITurnHandler _player2TurnHandler;
        private IEventDispatcher _eventDispatcher;

        private void Awake()
        {
            InitializeEventDispatcher();
            InstallTurnDependencies();
            InstallHeroDependencies();
            InstallGameDependencies();

            InjectViewDependencies();
        }

        private void Start()
        {
            _game.StartGame();
        }
        
        private void InitializeEventDispatcher()
        {
            _eventDispatcher = new EventDispatcher();
        }

        private void InstallTurnDependencies()
        {
            _player1TurnHandler = new TurnHandler(TurnTypes.Turn.Player_1, _player1Heroes);
            _player2TurnHandler = new TurnHandler(TurnTypes.Turn.Player_2, _player2Heroes);
            _turnDealer = new TurnDealer(_player1TurnHandler, _player2TurnHandler);
        }
        
        private void InstallHeroDependencies()
        {
            InjectHeroControllerDependencies(_player1Heroes, _player1TurnHandler);
            InjectHeroControllerDependencies(_player2Heroes, _player2TurnHandler);
        }

        private void InjectHeroControllerDependencies(IEnumerable<HeroController> heroControllers, ITurnHandler turnHandler)
        {
            foreach (var heroController in heroControllers)
            {
                heroController.InjectDependencies(turnHandler, _eventDispatcher);
            }
        }
        
        private void InstallGameDependencies()
        {
            _game = new GameMain(_turnDealer);
        }

        private void InjectViewDependencies()
        {
            _heroActionsPanelView.InjectDependencies(_eventDispatcher);
        }

    }
}