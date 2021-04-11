﻿using System.Collections.Generic;
using Game;
using Game.ActionsExecutioner;
using Game.Turn;
using Game.Turn.Dealer;
using Game.Turn.Handlers;
using Heroes.Controllers;
using Services.EventDispatcher;
using UnityEngine;
using Views;

namespace Installers
{
    public class GameInstaller : MonoBehaviour
    {
        [Header("Game Main")]
        [SerializeField] private GameMain _gameMain;
        
        [Header("Heroes Controllers")]
        [SerializeField] private List<HeroController> _player1Heroes;
        [SerializeField] private List<HeroController> _player2Heroes;

        [Header("Views")]
        [SerializeField] private HeroActionsPanelView _heroActionsPanelView;

        private IGame _game;
        private ITurnDealer _turnDealer;
        private ITurnHandler _player1TurnHandler;
        private ITurnHandler _player2TurnHandler;
        private IEventDispatcher _eventDispatcher;
        private IGameActionsExecutioner _gameActionsExecutioner;

        private void Awake()
        {
            InitializeEventDispatcher();
            InstallTurnDependencies();
            InstallGameDependencies();
            InstallHeroDependencies();

            InjectViewDependencies();
        }

        private void Start()
        {
            _game.StartGame();
        }
        
        private void InitializeEventDispatcher()
        {
            _eventDispatcher = new EventDispatcher();
        }

        private void InstallTurnDependencies()
        {
            _player1TurnHandler = new TurnHandler(TurnTypes.Turn.Player_1, _player1Heroes);
            _player2TurnHandler = new TurnHandler(TurnTypes.Turn.Player_2, _player2Heroes);
            _turnDealer = new TurnDealer(_player1TurnHandler, _player2TurnHandler, _eventDispatcher);
        }
        
        private void InstallHeroDependencies()
        {
            InjectHeroControllerDependencies(_player1Heroes, _player1TurnHandler);
            InjectHeroControllerDependencies(_player2Heroes, _player2TurnHandler);
        }

        private void InjectHeroControllerDependencies(IEnumerable<HeroController> heroControllers, ITurnHandler turnHandler)
        {
            foreach (var heroController in heroControllers)
            {
                heroController.InjectDependencies(turnHandler, _eventDispatcher, _gameActionsExecutioner);
            }
        }
        
        private void InstallGameDependencies()
        {
            _gameActionsExecutioner = new GameActionsExecutioner(_turnDealer, _eventDispatcher);
            _game = _gameMain;
            _game.InjectDependencies(_gameActionsExecutioner, _turnDealer, _eventDispatcher);
        }

        private void InjectViewDependencies()
        {
            _heroActionsPanelView.InjectDependencies(_eventDispatcher);
        }

    }
}