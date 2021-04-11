using Heroes.Actions;
using Services.Drag;
using UnityEngine;

namespace Heroes.Commands
{
    public class MoveCommand : ICommand
    {
        private readonly IHeroActionController _actionController;
        private readonly DragDto _dragDto;

        public MoveCommand(IHeroActionController actionController, DragDto dragDto)
        {
            _actionController = actionController;
            _dragDto = dragDto;
        }
        
        public void Execute()
        {
            Debug.Log($"Execute action <b>{nameof(MoveCommand)}</b>");
        }
    }
}