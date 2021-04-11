using System;
using Heroes.Commands;

namespace Heroes.Actions
{
    public interface IHeroActionSimulator
    {
        event System.Action OnActionSimulated;
        void CanSimulate(Action<ICommand> onSimulationFinished);
    }
}