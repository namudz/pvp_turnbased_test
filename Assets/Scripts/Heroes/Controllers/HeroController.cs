using Game.Turn.Handlers;
using Heroes.Actions;
using Heroes.Selector;
using Services.EventDispatcher;
using UnityEngine;

namespace Heroes.Controllers
{
    public class HeroController : MonoBehaviour
    {
        [Header("Stats")]
        [SerializeField] private HeroStatsConfig StatsConfig;

        [Header("Controllers")]
        [SerializeField] private HeroSelector _heroSelector;
        [SerializeField] private HeroActionSimulator _actionSimulator;

        private Hero _hero;
        private ITurnHandler _turnHandler;

        public void InjectDependencies(ITurnHandler turnHandler, IEventDispatcher eventDispatcher)
        {
            InitializeHeroEntity();
            _turnHandler = turnHandler;
            _heroSelector.InjectDependencies(
                _hero, 
                turnHandler, 
                _actionSimulator,
                eventDispatcher
            );
        }

        private void InitializeHeroEntity()
        {
            _hero = new Hero(StatsConfig);
        }
    }
}