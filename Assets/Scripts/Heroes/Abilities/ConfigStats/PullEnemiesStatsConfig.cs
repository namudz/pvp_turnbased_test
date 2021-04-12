using Heroes.Abilities.Types;
using UnityEngine;

namespace Heroes.Abilities.ConfigStats
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Heroes/Abilities/PullEnemiesConfiguration", order = 1)]
    public class PullEnemiesStatsConfig : AbilityStatsConfig
    {
        public float PullForce = 450f;
        public float PullRange = 30f;
        
        public PullEnemiesStatsConfig()
        {
            Type = HeroAbilityType.Type.PullEnemies;
        }
    }
}