using System.Collections.Generic;
using Game;
using Game.Turn;
using Game.Turn.Dealer;
using Game.Turn.Handlers;
using Heroes.Controllers;
using UnityEngine;

namespace Installers
{
    public class GameInstaller : MonoBehaviour
    {
        [Header("Heroes Controllers")]
        [SerializeField] private List<HeroController> _player1Heroes;
        [SerializeField] private List<HeroController> _player2Heroes;

        private IGame _game;
        private ITurnDealer _turnDealer;

        private void Awake()
        {
            InstallTurnDependencies();
            InstallGameDependencies();
        }

        private void InstallTurnDependencies()
        {
            var player1TurnHandler = new TurnHandler(TurnTypes.Turn.Player_1, _player1Heroes);
            var player2TurnHandler = new TurnHandler(TurnTypes.Turn.Player_2, _player2Heroes);
            _turnDealer = new TurnDealer(player1TurnHandler, player2TurnHandler);
        }
        
        private void InstallGameDependencies()
        {
            _game = new GameMain(_turnDealer);
        }
    }
}