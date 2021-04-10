using Game.Turn.Handlers;
using Heroes.Selector;
using Services;
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

        private Hero _hero;
        private ITurnHandler _turnHandler;

        public void InjectDependencies(ITurnHandler turnHandler, IEventDispatcher eventDispatcher)
        {
            InitializeHeroEntity();
            _turnHandler = turnHandler;
            _heroSelector.InjectDependencies(_hero, turnHandler, eventDispatcher);
        }

        private void InitializeHeroEntity()
        {
            _hero = new Hero(StatsConfig);
        }
    }
}