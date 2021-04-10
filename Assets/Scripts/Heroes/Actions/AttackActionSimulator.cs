using System;
using UnityEngine;

namespace Heroes.Actions
{
    public class AttackActionSimulator : MonoBehaviour, IHeroActionSimulator
    {
        public event Action OnActionSimulated;
        public void CanSimulate()
        {
            throw new NotImplementedException();
        }
    }
}