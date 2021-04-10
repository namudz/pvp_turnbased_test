using Heroes.Abilities.Types;
using UnityEngine;

namespace Heroes.Abilities.ConfigStats
{
    public abstract class AbilityStatsConfig : ScriptableObject
    {
        public HeroAbilityType.Type Type { get; protected set; }
    }
}