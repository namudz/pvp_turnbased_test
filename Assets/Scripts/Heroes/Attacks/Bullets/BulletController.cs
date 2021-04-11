using Heroes.Health;
using Services;
using Services.Pooling;
using UnityEngine;

namespace Heroes.Attacks.Bullets
{
    public class BulletController : MonoBehaviour, IPoolable
    {
        [SerializeField] private Transform _myTransform;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Collider _collider;

        private const float Speed = 980f;
        
        private IGameObjectPool<BulletController> _pool;
        private int _shooterInstanceId;
        private float _damage;
        private int _wallLayerMask;

        private void Awake()
        {
            _wallLayerMask = LayerMask.NameToLayer("Wall");
        }

        private void Start()
        {
            _pool = ServiceLocator.Instance.GetService<IGameObjectPool<BulletController>>();
        }

        public void SetData(int instanceId, float damage)
        {
            _shooterInstanceId = instanceId;
            _damage = damage;
        }

        public void Shoot(float angle, Vector3 origin)
        {
            _myTransform.position = origin;
            
            _collider.enabled = true;
            _myTransform.localRotation = Quaternion.AngleAxis(angle, Vector3.up);

            var direction = _myTransform.TransformDirection(Vector3.forward);
            _rigidbody.AddRelativeForce(direction * Speed, ForceMode.Acceleration);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == _wallLayerMask)
            {
                DeactivateOnCollision(); 
                return;
            }
            
            var healthController = other.GetComponent<HeroHealthController>();
            if (healthController == null
                || healthController.HeroInstanceId == _shooterInstanceId)
            {
                return;
            }
            
            healthController.HeroHealth.Damage(_damage);
            HandleEnemyHit();
        }

        private void HandleEnemyHit()
        {
            _collider.enabled = false;
            DeactivateOnCollision();
        }

        private void DeactivateOnCollision()
        {
            gameObject.SetActive(false);
            _pool.BackToPool(gameObject);
        }
    }
}