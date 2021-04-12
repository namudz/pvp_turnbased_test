using System.Collections.Generic;
using Game.Turn;
using Game.Turn.Dealer;
using Heroes;
using Heroes.Controllers;
using Services.EventDispatcher;

namespace Game
{
    public class GameMain : IGame
    {
        private ITurnDealer _turnDealer;
        private IEventDispatcher _eventDispatcher;

        private List<HeroController> _player1Heroes;
        private List<HeroController> _player2Heroes;

        public GameMain(ITurnDealer turnDealer, IEventDispatcher eventDispatcher)
        {
            _turnDealer = turnDealer;
            _eventDispatcher = eventDispatcher;
        }

        public void SetHeroes(List<HeroController> heroesPlayer1, List<HeroController> heroesPlayer2)
        {
            _player1Heroes = heroesPlayer1;
            foreach (var heroController in _player1Heroes)
            {
                heroController.OnHeroDeath += HandleHeroDeath;
            }
            
            _player2Heroes = heroesPlayer2;
            foreach (var heroController in _player2Heroes)
            {
                heroController.OnHeroDeath += HandleHeroDeath;
            }
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

        private void HandleHeroDeath(int heroInstanceId)
        {
            if (CheckPlayerVictory(heroInstanceId, _player2Heroes, HeroTypes.Team.Player_1)) { return; }

            CheckPlayerVictory(heroInstanceId, _player1Heroes, HeroTypes.Team.Player_2);
        }

        private bool CheckPlayerVictory(int heroInstanceId, List<HeroController> opponentHeroes, HeroTypes.Team teamWinner)
        {
            var deathHero = opponentHeroes.Find(heroHealth => heroHealth.HeroInstanceId == heroInstanceId);
            if (deathHero == null) { return false; }
            
            opponentHeroes.Remove(deathHero);
            if (opponentHeroes.Count != 0) { return false; }
            
            LaunchGameOverSignal(teamWinner);
            return true;

        }
        
        private void LaunchGameOverSignal(HeroTypes.Team teamWinner)
        {
            _eventDispatcher.Dispatch(new GameOverSignal(teamWinner));
        }
    }
}