using Heroes.Actions;

namespace Heroes.Commands.Ability
{
    public abstract class AbilityCommand : ICommand
    {
        private readonly IHeroActionController _heroActionController;

        protected AbilityCommand(IHeroActionController heroActionController)
        {
            _heroActionController = heroActionController;
        }
        
        public abstract void Execute();
    }
}