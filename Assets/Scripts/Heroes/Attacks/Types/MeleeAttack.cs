using System;

namespace Heroes.Attacks.Types
{
    public class MeleeAttack : IHeroAttack
    {
        public HeroAttackType.Type Type => HeroAttackType.Type.Melee;
        public float AttackPoints { get; }
        
        public void Attack()
        {
            throw new NotImplementedException();
        }
    }
}