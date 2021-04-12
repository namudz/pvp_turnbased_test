using UnityEngine;

namespace Heroes.Movement
{
    public class HeroMovementController : MonoBehaviour, IHeroMovement
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Transform _myTransform;
        
        private Hero _hero;

        public void InjectDependencies(Hero hero)
        {
            _hero = hero;
        }

        public void Move(float angle, float forceMultiplier)
        {
            _myTransform.localRotation = Quaternion.AngleAxis(angle, Vector3.up);

            var force = _myTransform.forward * (_hero.MaxMovementForce * forceMultiplier);
            _rigidbody.AddForce(force, ForceMode.Impulse);
        }

        public void Pull(Vector3 casterPosition, float force, float range)
        {
            _rigidbody.AddExplosionForce(-force, casterPosition, range);
        }

        public void Push(Vector3 casterPosition, float force, float range)
        {
            _rigidbody.AddExplosionForce(force, casterPosition, range);
        }
    }
}