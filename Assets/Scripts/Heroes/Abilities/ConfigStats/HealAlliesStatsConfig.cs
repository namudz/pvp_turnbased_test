using Heroes.Abilities.Types;
using UnityEngine;

namespace Heroes.Abilities.ConfigStats
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Heroes/Abilities/HealAlliesConfiguration", order = 1)]
    public class HealAlliesStatsConfig : AbilityStatsConfig
    {
        [Header("Heal Points")]
        public float HealPoints;

        public HealAlliesStatsConfig()
        {
            Type = HeroAbilityType.Type.HealAllies;
        }
    }
}