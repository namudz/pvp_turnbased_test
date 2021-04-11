using System;
using Heroes.Commands;
using UnityEngine;

namespace Heroes.Actions.Simulation
{
    public class AbilityActionSimulator : MonoBehaviour, IHeroActionSimulator
    {
        public event Action OnActionSimulated;
        
        [SerializeField] private HeroActionController _heroActionController;

        private Hero _hero;

        public void InjectDependencies(Hero hero)
        {
            _hero = hero;
        }

        public void CanSimulate(Action<ICommand> onSimulationFinished)
        {
            throw new NotImplementedException();
        }
    }
}