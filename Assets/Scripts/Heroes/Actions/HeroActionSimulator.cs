using System;
using UnityEngine;

namespace Heroes.Actions
{
    public class HeroActionSimulator : MonoBehaviour, IHeroActionSimulator
    {
        public event Action OnActionSimulated;

        [SerializeField] private MoveActionSimulator _moveSimulator;
        [SerializeField] private AttackActionSimulator _attackSimulator;
        [SerializeField] private AbilityActionSimulator _abilitySimulator;
        
        public void CanSimulate()
        {
            throw new NotImplementedException();
        }
    }
}