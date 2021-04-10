using Heroes.Abilities.Types;
using UnityEngine;

namespace Heroes.Abilities.ConfigStats
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Heroes/Abilities/PullEnemiesConfiguration", order = 1)]
    public class PullEnemiesStatsConfig : AbilityStatsConfig
    {
        [Header("Pull Force")]
        public float PullForce;
        
        public PullEnemiesStatsConfig()
        {
            Type = HeroAbilityType.Type.PullEnemies;
        }
    }
}