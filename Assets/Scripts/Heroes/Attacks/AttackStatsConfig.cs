using UnityEngine;

namespace Heroes.Attacks
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Heroes/HeroAttackConfiguration", order = 1)]
    public class AttackStatsConfig : ScriptableObject
    {
        [Header("Type")]
        public AttackTypes.Types Type;

        [Header("Points")]
        public float AttackPoints;
    }
}