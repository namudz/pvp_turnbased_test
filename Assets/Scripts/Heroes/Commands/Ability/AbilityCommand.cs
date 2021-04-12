using System;
using Heroes.Abilities;
using Heroes.Actions;

namespace Heroes.Commands.Ability
{
    public abstract class AbilityCommand : ICommand
    {
        public event Action OnCompleted;
        public HeroActionType.Type Type => HeroActionType.Type.Ability;
        protected readonly Hero _hero;
        protected readonly HeroAbilityController _abilityController;

        protected AbilityCommand(Hero hero, HeroAbilityController abilityController)
        {
            _hero = hero;
            _abilityController = abilityController;
        }
        
        public abstract void Execute();
        
        protected void LaunchOnCompletedEvent()
        {
            OnCompleted?.Invoke();
        }
    }
}