using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Game.Turn;
using Game.Turn.Dealer;
using Heroes.Commands;
using Services.EventDispatcher;

namespace Game.ActionsExecutioner
{
    public class GameActionsExecutioner : IGameActionsExecutioner
    {
        private const int ActionDelay = 1;
        private readonly ITurnDealer _turnDealer;
        private readonly IEventDispatcher _eventDispatcher;
        private Queue<ICommand> _actionsToExecute;
        private bool _executingActions;
        private bool _allActionsExecuted;
        private bool _isMyTurn;

        public GameActionsExecutioner(ITurnDealer turnDealer, IEventDispatcher eventDispatcher)
        {
            _turnDealer = turnDealer;
            _eventDispatcher = eventDispatcher;
            _actionsToExecute = new Queue<ICommand>();

            _turnDealer.OnTurnChanged += HandleTurnChanged;
        }

        public void AddAction(ICommand command)
        {
            _actionsToExecute.Enqueue(command);
        }

        public void Tick()
        {
            // As I'm using Tasks to add delay between actions, can't access Unity components on a diff thread.
            // That's why I'm ticking this class
            // The turn is changed to Player1 after all actions are executed
            
            if (!_isMyTurn || _executingActions || !_allActionsExecuted) { return; }
            AllActionsExecuted();
        }

        public void Reset()
        {
            _actionsToExecute.Clear();
        }
        
        private void HandleTurnChanged(TurnTypes.Turn turn)
        {
            if (turn != TurnTypes.Turn.CPU)
            {
                _isMyTurn = false;
                return;
            }

            _isMyTurn = true;
            Task.Run(ExecuteAllActions);
        }
        
        private async Task ExecuteAllActions()
        {
            _executingActions = true;
            _allActionsExecuted = false;
            
            var actionsCounter = _actionsToExecute.Count;
            for (var i = 0; i < actionsCounter; ++i)
            {
                var action = _actionsToExecute.Dequeue();
                action.Execute();
                --actionsCounter;
                --i;
                
                // Adding some delay to actions for a better gameplay
                await Task.Delay(TimeSpan.FromSeconds(ActionDelay));
            }

            _executingActions = false;
            _allActionsExecuted = true;
        }

        private void AllActionsExecuted()
        {
            _eventDispatcher.Dispatch(new GameActionsExecutedSignal());
        }
    }
}