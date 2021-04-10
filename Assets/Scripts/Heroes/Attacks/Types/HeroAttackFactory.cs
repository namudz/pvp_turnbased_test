using System;

namespace Heroes.Attacks.Types
{
    public static class AttackFactory
    {
        public static IHeroAttack GetAttack(AttackStatsConfig attackConfig)
        {
            switch (attackConfig.Type)
            {
                case HeroAttackType.Type.Melee:
                    return new MeleeAttack();
                case HeroAttackType.Type.Range:
                    return new RangeAttack();
                default:
                    throw new ArgumentOutOfRangeException(nameof(attackConfig.Type), attackConfig.Type, null);
            }
        }
    }
}