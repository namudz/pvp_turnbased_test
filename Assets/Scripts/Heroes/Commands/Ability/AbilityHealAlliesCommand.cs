using Heroes.Actions;
using UnityEngine;

namespace Heroes.Commands.Ability
{
    public class AbilityHealAlliesCommand : AbilityCommand
    {
        public AbilityHealAlliesCommand(IHeroActionController heroActionController) : base(heroActionController)
        {
        }
        
        public override void Execute()
        {
            Debug.Log($"Execute action <b>{nameof(AbilityHealAlliesCommand)}</b>");
        }
    }
}