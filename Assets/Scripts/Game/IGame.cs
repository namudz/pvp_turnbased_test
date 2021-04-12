using System.Collections.Generic;
using Heroes.Controllers;

namespace Game
{
    public interface IGame
    {
        void SetHeroes(List<HeroController> heroesPlayer1, List<HeroController> heroesPlayer2);
        void GameReady();
        void StartGame();
        void ResetGame();
    }
}