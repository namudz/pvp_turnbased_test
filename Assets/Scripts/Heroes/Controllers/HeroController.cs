using Game.ActionsExecutioner;
using Game.Turn.Handlers;
using Heroes.Abilities;
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
        [SerializeField] private HeroAbilityController _heroAbilityController;

        [Header("Views")]
        [SerializeField] private HeroGuiView _guiView;

        private Hero _hero;
        private ITurnHandler _turnHandler;
        
        public IHeroHealth HeroHealth { get; private set; }
        public int HeroInstanceId => _hero.InstanceId;
        public HeroTypes.Team HeroTeam => _hero.Team;

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
            _guiView.InjectDependencies(_hero, HeroHealth);
            _heroHealthController.InjectDependencies(_hero, HeroHealth);
            _heroAttackController.InjectDependencies(_hero);
            _heroAbilityController.InjectDependencies(_hero);
        }

        private void Start()
        {
            _heroActionController.OnActionSimulationFinished += LaunchActionSimulationFinishedEvent;
        }

        private void InitializeHeroEntity(int heroInstanceId)
        {
            _hero = new Hero(heroInstanceId, StatsConfig);
            HeroHealth = new HeroHealth(_hero);
        }
        
        private void LaunchActionSimulationFinishedEvent()
        {
            OnActionSimulationFinished?.Invoke();
        }
    }
}