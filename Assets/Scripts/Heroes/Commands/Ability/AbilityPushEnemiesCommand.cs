using Heroes.Actions;
using UnityEngine;

namespace Heroes.Commands.Ability
{
    public class AbilityPushEnemiesCommand : AbilityCommand
    {
        public AbilityPushEnemiesCommand(Hero hero) : base(hero)
        {
        }

        public override void Execute()
        {
            Debug.Log($"Execute action <b>{nameof(AbilityPushEnemiesCommand)}</b>");
        }
    }
}