using Heroes.Actions;
using Heroes.Attacks;

namespace Heroes.Commands.Attack
{
    public class AttackMeleeCommand : ActionCommand
    {
        public override HeroActionType.Type Type => HeroActionType.Type.Attack;
        private readonly HeroAttackController _attackController;

        public AttackMeleeCommand(Hero hero, HeroAttackController attackController) : base(hero)
        {
            _attackController = attackController;
        }
        
        protected override void ExecuteAction()
        {
            _attackController.AttackMelee(_hero.Attack, LaunchOnCompletedEvent);
        }
    }
}