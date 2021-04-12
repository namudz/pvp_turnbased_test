using Heroes.Attacks.Types;
using UnityEngine;

namespace Heroes.Attacks
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Heroes/HeroAttackConfiguration", order = 1)]
    public class AttackStatsConfig : ScriptableObject
    {
        [Header("Type")]
        public HeroAttackType.Type Type;

        [Header("Points")]
        public float AttackPoints;
    }
}