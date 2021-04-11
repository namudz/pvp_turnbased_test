using Heroes.Commands;

namespace Game.ActionsExecutioner
{
    public interface IGameActionsExecutioner
    {
        void AddAction(ICommand command);
        void Tick();
        void Reset();
    }
}