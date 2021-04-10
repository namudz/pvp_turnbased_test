using System;
using Game.Turn.Handlers;

namespace Game.Turn.Dealer
{
    public class TurnDealer : ITurnDealer
    {
        private readonly TurnHandler _player1TurnHandler;
        private readonly TurnHandler _player2TurnHandler;
        public event Action<TurnTypes.Turn> OnTurnChanged;

        private TurnTypes.Turn _currentTurn;

        public TurnDealer(TurnHandler player1TurnHandler, TurnHandler player2TurnHandler)
        {
            _player1TurnHandler = player1TurnHandler;
            _player2TurnHandler = player2TurnHandler;
            
            _player1TurnHandler.InjectDependencies(this);
            _player2TurnHandler.InjectDependencies(this);

            _player1TurnHandler.OnTurnFinished += ChangeTurnToPlayer2;
            _player2TurnHandler.OnTurnFinished += ChangeTurnToCPU;
        }

        ~TurnDealer()
        {
            _player1TurnHandler.OnTurnFinished -= ChangeTurnToPlayer2;
            _player2TurnHandler.OnTurnFinished -= ChangeTurnToCPU;
        }
        
        public void SetCurrentTurn(TurnTypes.Turn newTurn)
        {
            _currentTurn = newTurn;
            OnTurnChanged?.Invoke(_currentTurn);
        }

        private void ChangeTurnToPlayer2()
        {
            SetCurrentTurn(TurnTypes.Turn.Player_2);
        }

        private void ChangeTurnToCPU()
        {
            SetCurrentTurn(TurnTypes.Turn.CPU);
        }
    }
}