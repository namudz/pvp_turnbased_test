using Heroes.Actions;
using Heroes.Attacks;
using Services.Drag;

namespace Heroes.Commands.Attack
{
    public class AttackRangeCommand : ActionCommand
    {
        public override HeroActionType.Type Type => HeroActionType.Type.Attack;
        private readonly HeroAttackController _attackController;
        private readonly DragDto _dragDto;

        public AttackRangeCommand(Hero hero, HeroAttackController attackController, DragDto dragDto) : base(hero)
        {
            _attackController = attackController;
            _dragDto = dragDto;
        }

        protected override void ExecuteAction()
        {
            _attackController.AttackRange(_hero.Attack, 360f - _dragDto.Angle, LaunchOnCompletedEvent);
        }
    }
}