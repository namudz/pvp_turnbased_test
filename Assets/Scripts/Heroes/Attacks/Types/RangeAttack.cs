namespace Heroes.Attacks.Types
{
    public class RangeAttack : HeroAttack
    {
        public override HeroAttackType.Type Type => HeroAttackType.Type.Range;
        
        public RangeAttack(float attackPoints) : base(attackPoints)
        {
        }
    }
}