using System;
using Heroes.Abilities.ConfigStats;

namespace Heroes.Abilities.Types
{
    public static class AbilityFactory
    {
        public static IHeroAbility GetAbility(AbilityStatsConfig abilityConfig)
        {
            if (abilityConfig == null) { return null; }
            
            switch (abilityConfig.Type)
            {
                case HeroAbilityType.Type.HealAllies:
                    return new HealAlliesAbility(((HealAlliesStatsConfig)abilityConfig).HealPoints);
                
                case HeroAbilityType.Type.PullEnemies:
                    var pullConfig = (PullEnemiesStatsConfig) abilityConfig;
                    return new PullEnemiesAbility(pullConfig.PullForce, pullConfig.PullRange);
                
                case HeroAbilityType.Type.PushEnemies:
                    var pushConfig = (PushEnemiesStatsConfig) abilityConfig;
                    return new PushEnemiesAbility(pushConfig.PushForce, pushConfig.PushRange);
                
                default:
                    throw new ArgumentOutOfRangeException(nameof(abilityConfig.Type), abilityConfig.Type, null);
            }
        }
    }
}