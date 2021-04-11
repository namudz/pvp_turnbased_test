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