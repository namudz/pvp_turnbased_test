using System.Collections.Generic;
using Game.Turn.Dealer;
using Heroes.Controllers;

namespace Game.Turn.Handlers
{
    public class TurnHandler : ITurnHandler
    {
        public event System.Action OnTurnStart;
        public event System.Action OnTurnFinished;

        private readonly TurnTypes.Turn _myTurnType;
        private readonly List<HeroController> _heroesControllers;
        private ITurnDealer _turnDealer;

        public TurnHandler(TurnTypes.Turn myTurn, List<HeroController> heroesControllers)
        {
            _myTurnType = myTurn;
            _heroesControllers = heroesControllers;
            SubscribeToHeroesEvents();
        }

        public void InjectDependencies(ITurnDealer turnDealer)
        {
            _turnDealer = turnDealer;
            _turnDealer.OnTurnChanged += OnTurnChanged;
        }

        private void SubscribeToHeroesEvents()
        {
            foreach (var hero in _heroesControllers)
            {
                
            }
        }

        private void OnTurnChanged(TurnTypes.Turn turn)
        {
            if (turn != _myTurnType)
            { 
                return;
            }
            StartTurn();
        }

        private void TurnFinished()
        {
            OnTurnFinished?.Invoke();
        }

        private void StartTurn()
        {
            OnTurnStart?.Invoke();
        }
    }
}