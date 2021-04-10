﻿using System;
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
                    return new HealAlliesAbility();
                case HeroAbilityType.Type.PullEnemies:
                    return new PullEnemiesAbility();
                case HeroAbilityType.Type.PushEnemies:
                    return new PushEnemiesAbility();
                default:
                    throw new ArgumentOutOfRangeException(nameof(abilityConfig.Type), abilityConfig.Type, null);
            }
        }
    }
}