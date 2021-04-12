using System;
using Heroes.Actions;

namespace Heroes.Commands
{
    public abstract class ActionCommand : ICommand
    {
        public event Action OnCompleted;
        public abstract HeroActionType.Type Type { get; }
        
        protected readonly Hero _hero;

        protected ActionCommand(Hero hero)
        {
            _hero = hero;
        }

        public void Execute()
        {
            if (!_hero.IsAlive()) { return; }

            ExecuteAction();
        }

        protected abstract void ExecuteAction();

        protected void LaunchOnCompletedEvent()
        {
            OnCompleted?.Invoke();
        }
    }
}