using Heroes.Abilities;

namespace Heroes.Commands.Ability
{
    public abstract class AbilityCommand : ICommand
    {
        protected readonly Hero _hero;
        protected readonly HeroAbilityController _abilityController;

        protected AbilityCommand(Hero hero, HeroAbilityController abilityController)
        {
            _hero = hero;
            _abilityController = abilityController;
        }
        
        public abstract void Execute();
    }
}