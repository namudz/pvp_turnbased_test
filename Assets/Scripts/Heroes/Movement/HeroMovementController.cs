using System;
using UnityEngine;

namespace Heroes.Movement
{
    public class HeroMovementController : MonoBehaviour, IHeroMovement
    {
        [SerializeField] private Rigidbody _rigidbody;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Move();
            }
        }

        public void Move()
        {
            _rigidbody.AddForce(transform.forward * 5f, ForceMode.Impulse);
        }
    }
}