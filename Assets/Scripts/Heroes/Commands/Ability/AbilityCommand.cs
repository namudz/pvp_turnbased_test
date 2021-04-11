namespace Heroes.Commands.Ability
{
    public abstract class AbilityCommand : ICommand
    {
        protected readonly Hero _hero;

        protected AbilityCommand(Hero hero)
        {
            _hero = hero;
        }
        
        public abstract void Execute();
    }
}