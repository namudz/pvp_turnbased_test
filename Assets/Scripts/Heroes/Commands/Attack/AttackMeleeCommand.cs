using Heroes.Actions;

namespace Heroes.Commands.Attack
{
    public class AttackMeleeCommand : ICommand
    {
        private readonly IHeroActionController _heroActionController;

        public AttackMeleeCommand(IHeroActionController heroActionController)
        {
            _heroActionController = heroActionController;
        }
        
        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}