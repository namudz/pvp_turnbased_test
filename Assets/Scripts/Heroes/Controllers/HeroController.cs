using Game.ActionsExecutioner;
using Game.Turn.Handlers;
using Heroes.Actions;
using Heroes.Attacks;
using Heroes.Health;
using Heroes.Movement;
using Heroes.Selector;
using Services.EventDispatcher;
using UnityEngine;
using Views;

namespace Heroes.Controllers
{
    public class HeroController : MonoBehaviour
    {
        public event System.Action OnActionSimulationFinished;
        
        [Header("Stats")]
        [SerializeField] private HeroStatsConfig StatsConfig;

        [Header("Controllers")]
        [SerializeField] private HeroSelector _heroSelector;
        [SerializeField] private HeroActionController _heroActionController;
        [SerializeField] private HeroMovementController _heroMovementController;
        [SerializeField] private HeroHealthController _heroHealthController;
        [SerializeField] private HeroAttackController _heroAttackController;

        [Header("Views")]
        [SerializeField] private HeroGuiView _guiView;

        private Hero _hero;
        private IHeroHealth _heroHealth;
        private ITurnHandler _turnHandler;

        public void InjectDependencies(
            int heroInstanceId, 
            ITurnHandler turnHandler,
            IEventDispatcher eventDispatcher,
            IGameActionsExecutioner gameActionsExecutioner)
        {
            InitializeHeroEntity(heroInstanceId);
            _turnHandler = turnHandler;
            _heroSelector.InjectDependencies(
                _hero, 
                turnHandler, 
                _heroActionController,
                eventDispatcher
            );
            _heroActionController.InjectDependencies(_hero, gameActionsExecutioner);
            _heroMovementController.InjectDependencies(_hero);
            _guiView.InjectDependencies(_hero, _heroHealth);
            _heroHealthController.InjectDependencies(_hero, _heroHealth);
            _heroAttackController.InjectDependencies(_hero);
        }

        private void Start()
        {
            _heroActionController.OnActionSimulationFinished += LaunchActionSimulationFinishedEvent;
        }

        private void InitializeHeroEntity(int heroInstanceId)
        {
            _hero = new Hero(heroInstanceId, StatsConfig);
            _heroHealth = new HeroHealth(_hero);
        }
        
        private void LaunchActionSimulationFinishedEvent()
        {
            OnActionSimulationFinished?.Invoke();
        }
    }
}