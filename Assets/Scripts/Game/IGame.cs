using Game.ActionsExecutioner;
using Game.Turn.Dealer;
using Services.EventDispatcher;

namespace Game
{
    public interface IGame
    {
        void InjectDependencies(
            IGameActionsExecutioner gameActionsExecutioner, 
            ITurnDealer turnDealer, 
            IEventDispatcher eventDispatcher
        );
        void GameReady();
        void StartGame();
        void ResetGame();
        void PauseGame();
        void QuitGame();
    }
}