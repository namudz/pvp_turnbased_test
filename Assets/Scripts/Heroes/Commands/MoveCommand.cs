using Services.Drag;

namespace Heroes.Commands
{
    public class MoveCommand : ICommand
    {
        private readonly DragDto _dragDto;

        public MoveCommand(DragDto dragDto)
        {
            _dragDto = dragDto;
        }
        
        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}