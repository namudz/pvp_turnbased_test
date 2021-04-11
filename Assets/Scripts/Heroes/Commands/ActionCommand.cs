namespace Heroes.Commands
{
    public abstract class ActionCommand : ICommand
    {
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
    }
}