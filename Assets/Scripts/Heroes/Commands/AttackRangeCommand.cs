using Heroes.Actions;
using Services.Drag;

namespace Heroes.Commands
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
            throw new System.NotImplementedException();
        }
    }
}