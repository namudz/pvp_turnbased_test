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
    }
}