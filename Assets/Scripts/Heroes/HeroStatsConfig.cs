using Heroes.Abilities.ConfigStats;
using Heroes.Attacks;
using UnityEngine;

namespace Heroes
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Heroes/HeroConfiguration", order = 1)]
    public class HeroStatsConfig : ScriptableObject
    {
        [Header ("Hero Stats")]
        [Min(1f)]
        public float HealthPoints = 1f;
        [Range(1, 9)]
        public int MovementRange = 1;

        [Header("Attack")]
        public AttackStatsConfig AttackConfig;

        [Header("Ability")]
        public AbilityStatsConfig AbilityConfig;
    }
}