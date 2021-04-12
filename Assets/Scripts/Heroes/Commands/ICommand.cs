using System;
using Heroes.Actions;

namespace Heroes.Commands
{
    public interface ICommand
    {
        event Action OnCompleted;
        HeroActionType.Type Type { get; }
        void Execute();
    }
}