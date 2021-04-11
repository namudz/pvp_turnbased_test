using Heroes.Actions;

namespace Heroes.Commands.Ability
{
    public class AbilityPullEnemiesCommand : AbilityCommand
    {
        public AbilityPullEnemiesCommand(IHeroActionController heroActionController) : base(heroActionController)
        {
        }

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}