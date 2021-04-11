using System;
using Game.ActionsExecutioner;
using Game.Turn.Handlers;
using Services.EventDispatcher;

namespace Game.Turn.Dealer
{
    public class TurnDealer : ITurnDealer
    {
        private readonly ITurnHandler _player1TurnHandler;
        private readonly ITurnHandler _player2TurnHandler;
        private readonly IEventDispatcher _eventDispatcher;
        public event Action<TurnTypes.Turn> OnTurnChanged;

        private TurnTypes.Turn _currentTurn;

        public TurnDealer(
            ITurnHandler player1TurnHandler, 
            ITurnHandler player2TurnHandler,
            IEventDispatcher eventDispatcher)
        {
            _player1TurnHandler = player1TurnHandler;
            _player2TurnHandler = player2TurnHandler;
            _eventDispatcher = eventDispatcher;

            _player1TurnHandler.InjectDependencies(this);
            _player2TurnHandler.InjectDependencies(this);

            _player1TurnHandler.OnTurnFinished += ChangeTurnToPlayer2;
            _player2TurnHandler.OnTurnFinished += ChangeTurnToCPU;
            _eventDispatcher.Subscribe<GameActionsExecutedSignal>(HandleAllActionsExecuted);
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

        private void ChangeTurnToPlayer1()
        {
            SetCurrentTurn(TurnTypes.Turn.Player_1);
        }

        private void ChangeTurnToPlayer2()
        {
            SetCurrentTurn(TurnTypes.Turn.Player_2);
        }

        private void ChangeTurnToCPU()
        {
            SetCurrentTurn(TurnTypes.Turn.CPU);
        }
        
        private void HandleAllActionsExecuted(ISignal signal)
        {
            // TODO: check if game is over
            ChangeTurnToPlayer1();
        }
    }
}