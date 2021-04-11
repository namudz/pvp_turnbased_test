using Game.Turn;
using Game.Turn.Dealer;
using Services.EventDispatcher;

namespace Game
{
    public class GameMain : IGame
    {
        private ITurnDealer _turnDealer;
        private IEventDispatcher _eventDispatcher;

        private GameStates.States _currentState;

        public GameMain(ITurnDealer turnDealer, IEventDispatcher eventDispatcher)
        {
            _turnDealer = turnDealer;
            _eventDispatcher = eventDispatcher;
        }

        public void GameReady()
        {
            _eventDispatcher.Dispatch(new GameReadySignal());
        }

        public void StartGame()
        {
            _turnDealer.SetCurrentTurn(TurnTypes.Turn.Player_1);
            _eventDispatcher.Dispatch(new GameStartSignal());
        }

        public void ResetGame()
        {
            throw new System.NotImplementedException();
        }

        public void PauseGame()
        {
            throw new System.NotImplementedException();
        }

        public void QuitGame()
        {
            throw new System.NotImplementedException();
        }

        private void ChangeState(GameStates.States newState)
        {
            _currentState = newState;
        }
    }
}