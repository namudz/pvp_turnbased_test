using Heroes.Animator;
using Heroes.Health;
using UnityEngine;

namespace Heroes.Attacks
{
    public class HeroAttackController : MonoBehaviour
    {
        [SerializeField] private HeroAnimatorController _animatorController;

        [SerializeField] private SphereCollider _meleeCollider;
        private Hero _hero;
        private IHeroHealth _enemyToDamage;

        private void Awake()
        {
            _meleeCollider.enabled = false;
        }

        public void InjectDependencies(Hero hero)
        {
            _hero = hero;
        }

        public void AttackMelee(IHeroAttack type)
        {
            _meleeCollider.enabled = true;
            _animatorController.Attack(type.Type, DamageEnemy);
        }
        
        public void AttackRange(IHeroAttack type)
        {
            
        }

        private void OnTriggerEnter(Collider other)
        {
            var healthController = other.GetComponent<HeroHealthController>();
            if (healthController == null || healthController.HeroInstanceId == _hero.InstanceId) { return; }
            
            _enemyToDamage = healthController.HeroHealth;
            _meleeCollider.enabled = false;
        }

        private void DamageEnemy()
        {
            _enemyToDamage.Damage(_hero.Attack.AttackPoints);
        }
    }
}