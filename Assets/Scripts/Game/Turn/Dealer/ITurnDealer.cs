namespace Game.Turn.Dealer
{
    public interface ITurnDealer
    {
        event System.Action<TurnTypes.Turn> OnTurnChanged;
        void SetCurrentTurn(TurnTypes.Turn newTurn);
    }
}