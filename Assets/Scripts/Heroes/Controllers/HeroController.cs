using Game.ActionsExecutioner;
using Game.Turn.Handlers;
using Heroes.Actions;
using Heroes.Selector;
using Services.EventDispatcher;
using UnityEngine;

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

        private Hero _hero;
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
        }

        private void Start()
        {
            _heroActionController.OnActionSimulationFinished += LaunchActionSimulationFinishedEvent;
        }

        private void InitializeHeroEntity()
        {
            _hero = new Hero(StatsConfig);
        }
        
        private void LaunchActionSimulationFinishedEvent()
        {
            OnActionSimulationFinished?.Invoke();
        }
    }
}