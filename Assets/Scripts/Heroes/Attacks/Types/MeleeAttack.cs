namespace Heroes.Attacks.Types
{
    public class MeleeAttack : HeroAttack
    {
        public override HeroAttackType.Type Type => HeroAttackType.Type.Melee;
        
        public MeleeAttack(float attackPoints) : base(attackPoints)
        {
        }
    }
}