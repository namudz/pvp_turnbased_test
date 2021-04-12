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
                    return new MeleeAttack(attackConfig.AttackPoints);
                case HeroAttackType.Type.Range:
                    return new RangeAttack(attackConfig.AttackPoints);
                default:
                    throw new ArgumentOutOfRangeException(nameof(attackConfig.Type), attackConfig.Type, null);
            }
        }
    }
}