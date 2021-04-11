using System;
using Heroes.Commands;
using UnityEngine;

namespace Heroes.Actions
{
    public class AbilityActionSimulator : MonoBehaviour, IHeroActionSimulator
    {
        public event Action OnActionSimulated;
        
        [SerializeField] private HeroActionController _heroActionController;
        
        public void CanSimulate(Action<ICommand> onSimulationFinished)
        {
            throw new NotImplementedException();
        }
    }
}