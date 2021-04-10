using System;
using UnityEngine;

namespace Heroes.Actions
{
    public class MoveActionSimulator : MonoBehaviour, IHeroActionSimulator
    {
        public event Action OnActionSimulated;
        
        public void CanSimulate()
        {
            throw new NotImplementedException();
        }
    }
}