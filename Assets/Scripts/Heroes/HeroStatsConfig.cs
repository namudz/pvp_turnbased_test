using Heroes.Abilities.ConfigStats;
using Heroes.Attacks;
using UnityEngine;

namespace Heroes
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Heroes/HeroConfiguration", order = 1)]
    public class HeroStatsConfig : ScriptableObject
    {
        [Header ("Hero Stats")]
        [Min(10f)]
        public float HealthPoints = 10f;

        [Min(10f)]
        public float MaxMovementForce = 10f;

        [Header("Attack")]
        public AttackStatsConfig AttackConfig;

        [Header("Ability")]
        public AbilityStatsConfig AbilityConfig;
    }
}