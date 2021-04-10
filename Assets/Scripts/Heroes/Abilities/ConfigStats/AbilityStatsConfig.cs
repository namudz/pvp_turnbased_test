using UnityEngine;

namespace Heroes.Abilities.ConfigStats
{
    public abstract class AbilityStatsConfig : ScriptableObject
    {
        public AbilitiesTypes.Types Type { get; protected set; }
    }
}