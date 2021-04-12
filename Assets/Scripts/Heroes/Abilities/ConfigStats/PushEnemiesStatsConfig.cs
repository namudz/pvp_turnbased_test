using Heroes.Abilities.Types;
using UnityEngine;

namespace Heroes.Abilities.ConfigStats
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Heroes/Abilities/PushEnemiesConfiguration", order = 1)]
    public class PushEnemiesStatsConfig : AbilityStatsConfig
    {
        public float PushForce = 450f;
        public float PushRange = 30f;
        
        public PushEnemiesStatsConfig()
        {
            Type = HeroAbilityType.Type.PushEnemies;
        }
    }
}