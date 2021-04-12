using System;
using Heroes.Commands;

namespace Heroes.Actions.Simulation
{
    public interface IHeroActionSimulator
    {
        event System.Action OnActionSimulated;
        void InjectDependencies(Hero hero);
        void CanSimulate(Action<ICommand> onSimulationFinished);
    }
}