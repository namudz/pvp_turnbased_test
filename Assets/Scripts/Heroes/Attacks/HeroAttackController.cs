using Heroes.Animator;
using UnityEngine;

namespace Heroes.Attacks
{
    public class HeroAttackController : MonoBehaviour
    {
        [SerializeField] private HeroAnimatorController _animatorController;

        public void AttackMelee(IHeroAttack type)
        {
            _animatorController.Attack(type.Type);
        }
        
        public void AttackRange(IHeroAttack type)
        {
            
        }
    }
}