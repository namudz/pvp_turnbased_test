using System;
using Heroes.Attacks.Types;
using UnityEngine;

namespace Heroes.Animator
{
    public class HeroAnimatorController : MonoBehaviour
    {
        [SerializeField] private UnityEngine.Animator _animator;
        
        private static readonly int MeleeAttackTrigger = UnityEngine.Animator.StringToHash("MeleeAttack");
        private static readonly int RangeAttack = UnityEngine.Animator.StringToHash("RangeAttack");
        private static readonly int HitTrigger = UnityEngine.Animator.StringToHash("Hit");
        private static readonly int DieTrigger = UnityEngine.Animator.StringToHash("Die");
        private Action _damageCallback;

        public void Attack(HeroAttackType.Type attackType, Action damageAnimationCallback)
        {
            _damageCallback = damageAnimationCallback;
            switch (attackType)
            {
                case HeroAttackType.Type.Melee:
                    _animator.SetTrigger(MeleeAttackTrigger);
                    break;
                case HeroAttackType.Type.Range:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(attackType), attackType, null);
            }
        }

        public void Hit()
        {
            _animator.SetTrigger(HitTrigger);
        }

        public void Die()
        {
            _animator.SetTrigger(DieTrigger);
        }

        public void ApplyDamage()
        {
            _damageCallback?.Invoke();
        }
    }
}