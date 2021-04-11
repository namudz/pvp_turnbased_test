using Heroes.Actions;

namespace Heroes.Commands.Ability
{
    public class AbilityHealAlliesCommand : AbilityCommand
    {
        public AbilityHealAlliesCommand(IHeroActionController heroActionController) : base(heroActionController)
        {
        }
        
        public override void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}