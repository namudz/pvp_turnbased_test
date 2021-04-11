using Heroes.Actions;
using UnityEngine;

namespace Heroes.Commands.Ability
{
    public class AbilityPullEnemiesCommand : AbilityCommand
    {
        public AbilityPullEnemiesCommand(Hero hero) : base(hero)
        {
        }

        public override void Execute()
        {
            Debug.Log($"Execute action <b>{nameof(AbilityPullEnemiesCommand)}</b>");
        }
    }
}