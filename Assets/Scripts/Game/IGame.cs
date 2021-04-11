using Game.Turn.Dealer;
using Services.EventDispatcher;

namespace Game
{
    public interface IGame
    {
        void GameReady();
        void StartGame();
        void ResetGame();
        void PauseGame();
        void QuitGame();
    }
}