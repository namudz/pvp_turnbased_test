using Heroes.Actions;
using UnityEngine;

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
            Debug.Log($"Execute action <b>{nameof(AttackMeleeCommand)}</b>");
        }
    }
}