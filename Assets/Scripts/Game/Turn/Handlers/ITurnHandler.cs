using Game.Turn.Dealer;

namespace Game.Turn.Handlers
{
    public interface ITurnHandler
    {
        event System.Action OnTurnStart;
        event System.Action OnTurnFinished;

        void InjectDependencies(ITurnDealer turnDealer);
    }
}