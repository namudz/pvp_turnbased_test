using Heroes.Animator;
using UnityEngine;

namespace Heroes.Health
{
    public class HeroHealthController : MonoBehaviour
    {
        [SerializeField] private HeroAnimatorController _animatorController;
        
        private Hero _hero;
        private IHeroHealth _heroHealth;

        public void InjectDependencies(Hero hero, IHeroHealth heroHealth)
        {
            _hero = hero;
            _heroHealth = heroHealth;
        }
    }
}