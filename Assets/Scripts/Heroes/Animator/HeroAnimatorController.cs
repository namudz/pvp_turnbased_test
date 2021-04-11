using System;
using Heroes.Attacks.Types;
using UnityEngine;

namespace Heroes.Animator
{
    public class HeroAnimatorController : MonoBehaviour
    {
        [SerializeField] private UnityEngine.Animator _animator;
        
        private static readonly int MeleeAttack = UnityEngine.Animator.StringToHash("MeleeAttack");
        private static readonly int RangeAttack = UnityEngine.Animator.StringToHash("RangeAttack");

        public void Attack(HeroAttackType.Type attackType)
        {
            switch (attackType)
            {
                case HeroAttackType.Type.Melee:
                    _animator.SetTrigger(MeleeAttack);
                    break;
                case HeroAttackType.Type.Range:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(attackType), attackType, null);
            }
        }

        public void Hit()
        {
            
        }

        public void Die()
        {
        }

        public void ApplyDamage()
        {
            Debug.Log(nameof(ApplyDamage));
        }
    }
}