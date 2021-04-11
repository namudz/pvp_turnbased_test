using Heroes.Abilities;

namespace Heroes.Commands.Ability
{
    public class AbilityHealAlliesCommand : AbilityCommand
    {
        public AbilityHealAlliesCommand(Hero hero, HeroAbilityController abilityController) : base(hero, abilityController)
        {
            
        }
        
        public override void Execute()
        {
            if (_hero.Ability == null) { return; }
            _abilityController.Cast(_hero.Team);
        }
    }
}