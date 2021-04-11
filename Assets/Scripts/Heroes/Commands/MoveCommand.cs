using Heroes.Movement;
using Services.Drag;

namespace Heroes.Commands
{
    public class MoveCommand : ActionCommand
    {
        private readonly IHeroMovement _heroMovement;
        private readonly DragDto _dragDto;

        public MoveCommand(Hero hero, IHeroMovement heroMovement, DragDto dragDto) : base(hero)
        {
            _heroMovement = heroMovement;
            _dragDto = dragDto;
        }
        
        protected override void ExecuteAction()
        {
            _heroMovement.Move(360f - _dragDto.Angle, _dragDto.DistanceFactor);
        }
    }
}