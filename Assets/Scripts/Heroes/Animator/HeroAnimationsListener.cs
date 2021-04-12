using UnityEngine;

namespace Heroes.Animator
{
    public class HeroAnimationsListener : MonoBehaviour
    {
        private HeroAnimatorController _heroAnimatorController;

        private void Awake()
        {
            _heroAnimatorController = transform.GetComponentInParent<HeroAnimatorController>();
        }

        public void ApplyDamage()
        {
            _heroAnimatorController.ApplyDamage();
        }

        public void ShootBullet()
        {
            _heroAnimatorController.ShootBullet();
        }

        public void ApplyAbility()
        {
            _heroAnimatorController.ApplyAbility();
        }

        public void DieAnimationFinished()
        {
            _heroAnimatorController.DieAnimationFinished();
        }
    }
}