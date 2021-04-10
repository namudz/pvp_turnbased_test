using Heroes.Abilities.Types;
using UnityEngine;

namespace Heroes.Abilities.ConfigStats
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Heroes/Abilities/PushEnemiesConfiguration", order = 1)]
    public class PushEnemiesStatsConfig : AbilityStatsConfig
    {
        [Header("Push Force")]
        public float PushForce;
        
        public PushEnemiesStatsConfig()
        {
            Type = HeroAbilityType.Type.PushEnemies;
        }
    }
}