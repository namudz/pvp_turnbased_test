using Game.Turn.Handlers;
using Heroes.Actions;
using Heroes.GUI;
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
        [SerializeField] private HeroActionController _heroActionController;

        private Hero _hero;
        private ITurnHandler _turnHandler;

        public void InjectDependencies(ITurnHandler turnHandler, IEventDispatcher eventDispatcher)
        {
            InitializeHeroEntity();
            _turnHandler = turnHandler;
            _heroSelector.InjectDependencies(
                _hero, 
                turnHandler, 
                _heroActionController,
                eventDispatcher
            );
            _heroActionController.InjectDependencies(_hero);
        }

        private void InitializeHeroEntity()
        {
            _hero = new Hero(StatsConfig);
        }
    }
}