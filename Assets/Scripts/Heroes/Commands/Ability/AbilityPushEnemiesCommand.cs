using Heroes.Actions;

namespace Heroes.Commands.Ability
{
    public class AbilityPushEnemiesCommand : AbilityCommand
    {
        public AbilityPushEnemiesCommand(IHeroActionController heroActionController) : base(heroActionController)
        {
        }

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}