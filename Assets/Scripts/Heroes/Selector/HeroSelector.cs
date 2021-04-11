using Game.Turn.Handlers;
using Heroes.Actions;
using Heroes.GUI;
using Services.EventDispatcher;
using UnityEngine;

namespace Heroes.Selector
{
    public class HeroSelector : MonoBehaviour
    {
        public bool IsSelectable { get; private set; }

        [SerializeField] private HeroGuiController _heroGuiController;
        
        private Hero _hero;
        private ITurnHandler _turnHandler;
        private IHeroActionController _actionSimulator;
        private IEventDispatcher _eventDispatcher;

        private void Awake()
        {
            IsSelectable = false;
        }

        public void InjectDependencies(
            Hero hero, 
            ITurnHandler turnHandler,
            IHeroActionController moveActionSimulator,
            IEventDispatcher eventDispatcher)
        {
            _hero = hero;
            _turnHandler = turnHandler;
            _actionSimulator = moveActionSimulator;
            _eventDispatcher = eventDispatcher;

            _actionSimulator.OnActionStartSimulation += SetAsNotSelectable;
            _actionSimulator.OnActionSimulationFinished += UpdateGuiOnActionSimulated;
            _turnHandler.OnTurnStart += SetAsSelectable;
        }

        private void SetAsSelectable()
        {
            IsSelectable = true;
            _heroGuiController.ShowSelectableCircle();
        }

        private void SetAsNotSelectable()
        {
            IsSelectable = false;
        }
        
        private void UpdateGuiOnActionSimulated()
        {
            _heroGuiController.HideSelectableCircle();
        }

        private void OnMouseDown()
        {
            if (!IsSelectable) { return; }
            Select();
        }
        
        private void Select()
        {
            var signal = new HeroSelectedSignal(_hero);
            _eventDispatcher.Dispatch(signal);
            _heroGuiController.HighlightSelectableCircle();
        }
    }
}