using Game.Turn.Handlers;
using Heroes.Actions;
using Services.EventDispatcher;
using UnityEngine;

namespace Heroes.Selector
{
    public class HeroSelector : MonoBehaviour
    {
        public bool IsSelectable { get; private set; }
        
        private Hero _hero;
        private ITurnHandler _turnHandler;
        private IHeroActionSimulator _actionSimulator;
        private IEventDispatcher _eventDispatcher;

        private void Awake()
        {
            IsSelectable = false;
        }

        public void InjectDependencies(
            Hero hero, 
            ITurnHandler turnHandler,
            IHeroActionSimulator moveActionSimulator,
            IEventDispatcher eventDispatcher)
        {
            _hero = hero;
            _turnHandler = turnHandler;
            _actionSimulator = moveActionSimulator;
            _eventDispatcher = eventDispatcher;

            _actionSimulator.OnActionSimulated += SetAsNotSelectable;
            _turnHandler.OnTurnStart += SetAsSelectable;
        }

        private void SetAsSelectable()
        {
            IsSelectable = true;
        }

        private void SetAsNotSelectable()
        {
            IsSelectable = false;
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
        }
    }
}