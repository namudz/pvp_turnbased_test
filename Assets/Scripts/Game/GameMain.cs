using System;
using Game.ActionsExecutioner;
using Game.Turn;
using Game.Turn.Dealer;
using Services.EventDispatcher;
using UnityEngine;

namespace Game
{
    public class GameMain : MonoBehaviour, IGame
    {
        private IGameActionsExecutioner _gameActionsExecutioner;
        private ITurnDealer _turnDealer;
        private IEventDispatcher _eventDispatcher;

        private GameStates.States _currentState;

        public void InjectDependencies(
            IGameActionsExecutioner gameActionsExecutioner, 
            ITurnDealer turnDealer,
            IEventDispatcher eventDispatcher)
        {
            _gameActionsExecutioner = gameActionsExecutioner;
            _turnDealer = turnDealer;
            _eventDispatcher = eventDispatcher;
        }

        private void Update()
        {
            _gameActionsExecutioner.Tick();
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