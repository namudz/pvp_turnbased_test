using Game.Turn.Dealer;
using Heroes.Commands;
using Services.EventDispatcher;

namespace Game.ActionsExecutioner
{
    public interface IGameActionsExecutioner
    {
        void InjectDependencies(ITurnDealer turnDealer, IEventDispatcher eventDispatcher);
        void AddAction(ICommand command);
        void ResetActions();
    }
}