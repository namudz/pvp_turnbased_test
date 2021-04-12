using Heroes.Animator;
using UnityEngine;

namespace Heroes.Health
{
    public class HeroHealthController : MonoBehaviour
    {
        [SerializeField] private HeroAnimatorController _animatorController;
        
        public int HeroInstanceId => _hero.InstanceId;
        public IHeroHealth HeroHealth { get; private set; }
        
        private Hero _hero;

        public void InjectDependencies(Hero hero, IHeroHealth heroHealth)
        {
            _hero = hero;
            HeroHealth = heroHealth;

            HeroHealth.OnDamaged += PlayHitAnimation;
            HeroHealth.OnDeath += PlayDeathAnimation;
        }
        
        private void PlayHitAnimation(float obj)
        {
            _animatorController.Hit();
        }

        private void PlayDeathAnimation(int obj)
        {
            _animatorController.Die(Deactivate);
        }

        private void Deactivate()
        {
            gameObject.SetActive(false);
        }
    }
}