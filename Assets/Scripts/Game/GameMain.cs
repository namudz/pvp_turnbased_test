using Game.Turn;
using Game.Turn.Dealer;

namespace Game
{
    public class GameMain : IGame
    {
        private readonly ITurnDealer _turnDealer;
        
        private GameStates.States _currentState;
        
        public GameMain(ITurnDealer turnDealer)
        {
            _turnDealer = turnDealer;
        }

        public void StartGame()
        {
            _turnDealer.SetCurrentTurn(TurnTypes.Turn.Player_1);
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