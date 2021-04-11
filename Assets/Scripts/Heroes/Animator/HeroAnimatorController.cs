using System;
using Heroes.Attacks.Types;
using UnityEngine;

namespace Heroes.Animator
{
    public class HeroAnimatorController : MonoBehaviour
    {
        [SerializeField] private UnityEngine.Animator _animator;
        
        private static readonly int MeleeAttackTrigger = UnityEngine.Animator.StringToHash("MeleeAttack");
        private static readonly int RangeAttackTrigger = UnityEngine.Animator.StringToHash("RangeAttack");
        private static readonly int HitTrigger = UnityEngine.Animator.StringToHash("Hit");
        private static readonly int DieTrigger = UnityEngine.Animator.StringToHash("Die");
        private static readonly int AbilityTrigger = UnityEngine.Animator.StringToHash("Ability");
        private Action _attackAnimationCallback;
        private Action _abilityAnimationCallback;

        public void Attack(HeroAttackType.Type attackType, Action animationCallback)
        {
            _attackAnimationCallback = animationCallback;
            switch (attackType)
            {
                case HeroAttackType.Type.Melee:
                    _animator.SetTrigger(MeleeAttackTrigger);
                    break;
                case HeroAttackType.Type.Range:
                    _animator.SetTrigger(RangeAttackTrigger);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(attackType), attackType, null);
            }
        }

        public void CastAbility(Action animationCallback)
        {
            _abilityAnimationCallback = animationCallback;
            _animator.SetTrigger(AbilityTrigger);
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
            _attackAnimationCallback?.Invoke();
        }

        public void ShootBullet()
        {
            _attackAnimationCallback?.Invoke();
        }

        public void ApplyAbility()
        {
            _abilityAnimationCallback?.Invoke();
        }
    }
}