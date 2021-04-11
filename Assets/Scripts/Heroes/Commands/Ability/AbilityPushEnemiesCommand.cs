using Heroes.Actions;
using UnityEngine;

namespace Heroes.Commands.Ability
{
    public class AbilityPushEnemiesCommand : AbilityCommand
    {
        public AbilityPushEnemiesCommand(IHeroActionController heroActionController) : base(heroActionController)
        {
        }

        public override void Execute()
        {
            Debug.Log($"Execute action <b>{nameof(AbilityPushEnemiesCommand)}</b>");
        }
    }
}