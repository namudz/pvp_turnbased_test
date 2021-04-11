using Heroes.Actions;
using Services.Drag;
using UnityEngine;

namespace Heroes.Commands.Attack
{
    public class AttackRangeCommand : ICommand
    {
        private readonly IHeroActionController _heroActionController;
        private readonly DragDto _dragDto;

        public AttackRangeCommand(IHeroActionController heroActionController, DragDto dragDto)
        {
            _heroActionController = heroActionController;
            _dragDto = dragDto;
        }

        public void Execute()
        {
            Debug.Log($"Execute action <b>{nameof(AttackRangeCommand)}</b>");
        }
    }
}