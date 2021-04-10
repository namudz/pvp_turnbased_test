using System;

namespace Heroes.Attacks.Types
{
    public class RangeAttack : IHeroAttack
    {
        public HeroAttackType.Type Type => HeroAttackType.Type.Range;
        public float AttackPoints { get; }
        public void Attack()
        {
            throw new NotImplementedException();
        }
    }
}