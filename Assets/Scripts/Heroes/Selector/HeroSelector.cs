using Game.Turn.Handlers;
using Services.EventDispatcher;
using UnityEngine;

namespace Heroes.Selector
{
    public class HeroSelector : MonoBehaviour
    {
        public bool IsSelectable { get; private set; }
        
        private Hero _hero;
        private ITurnHandler _turnHandler;
        private IEventDispatcher _eventDispatcher;

        private void Awake()
        {
            IsSelectable = false;
        }

        public void InjectDependencies(Hero hero, ITurnHandler turnHandler, IEventDispatcher eventDispatcher)
        {
            _hero = hero;
            _turnHandler = turnHandler;
            _eventDispatcher = eventDispatcher;
            _turnHandler.OnTurnStart += SetAsSelectable;
        }

        public void ResetSelectable()
        {
            IsSelectable = true;
        }

        private void SetAsSelectable()
        {
            IsSelectable = true;
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
            IsSelectable = false;
        }
    }
}