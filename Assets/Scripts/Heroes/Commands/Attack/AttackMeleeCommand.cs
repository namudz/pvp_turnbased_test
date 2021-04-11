using Heroes.Attacks;

namespace Heroes.Commands.Attack
{
    public class AttackMeleeCommand : ActionCommand
    {
        private readonly HeroAttackController _attackController;

        public AttackMeleeCommand(Hero hero, HeroAttackController attackController) : base(hero)
        {
            _attackController = attackController;
        }
        
        protected override void ExecuteAction()
        {
            _attackController.AttackMelee(_hero.Attack);
        }
    }
}