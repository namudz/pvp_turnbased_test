using Game.ActionsExecutioner;
using Game.Turn.Handlers;
using Heroes.Actions;
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

        [Header("Views")]
        [SerializeField] private HeroGuiView _guiView;

        private Hero _hero;
        private IHeroHealth _heroHealth;
        private ITurnHandler _turnHandler;

        public void InjectDependencies(
            ITurnHandler turnHandler, 
            IEventDispatcher eventDispatcher,
            IGameActionsExecutioner gameActionsExecutioner)
        {
            InitializeHeroEntity();
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
        }

        private void Start()
        {
            _heroActionController.OnActionSimulationFinished += LaunchActionSimulationFinishedEvent;
        }

        private void InitializeHeroEntity()
        {
            _hero = new Hero(StatsConfig);
            _heroHealth = new HeroHealth(_hero);
        }
        
        private void LaunchActionSimulationFinishedEvent()
        {
            OnActionSimulationFinished?.Invoke();
        }
    }
}