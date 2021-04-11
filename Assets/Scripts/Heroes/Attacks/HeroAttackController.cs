using Heroes.Animator;
using Heroes.Attacks.Bullets;
using Heroes.Health;
using Services;
using Services.Pooling;
using UnityEngine;

namespace Heroes.Attacks
{
    public class HeroAttackController : MonoBehaviour
    {
        [SerializeField] private HeroAnimatorController _animatorController;
        [SerializeField] private SphereCollider _meleeCollider;
        [SerializeField] private Transform _bulletOrigin;
        
        private Hero _hero;
        private IHeroHealth _enemyToDamage;
        private BulletController _bullet;

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
        
        public void AttackRange(IHeroAttack type, float shootAngle)
        {
            _animatorController.Attack(type.Type, () =>
            {
                ShootBullet(shootAngle);
            });
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
            _enemyToDamage?.Damage(_hero.Attack.AttackPoints);
        }

        private void ShootBullet(float shootAngle)
        {
            var pool = ServiceLocator.Instance.GetService<IGameObjectPool<BulletController>>();
            _bullet = pool.GetInstance(transform.position).GetComponent<BulletController>();
            _bullet.SetData(_hero.InstanceId, _hero.Attack.AttackPoints);
            _bullet.Shoot(shootAngle, _bulletOrigin.position);
        }
    }
}