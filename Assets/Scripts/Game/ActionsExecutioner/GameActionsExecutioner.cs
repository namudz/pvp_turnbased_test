using System.Collections;
using System.Collections.Generic;
using Game.Turn;
using Game.Turn.Dealer;
using Heroes.Commands;
using Services.EventDispatcher;
using UnityEngine;

namespace Game.ActionsExecutioner
{
    public class GameActionsExecutioner : MonoBehaviour, IGameActionsExecutioner
    {
        private const int ActionDelay = 1;
        private ITurnDealer _turnDealer;
        private IEventDispatcher _eventDispatcher;
        private Queue<ICommand> _actionsToExecute;
        private Coroutine _executeActionsCoroutine;

        public void InjectDependencies(ITurnDealer turnDealer, IEventDispatcher eventDispatcher)
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

        public void ResetActions()
        {
            _actionsToExecute.Clear();
        }
        
        private void HandleTurnChanged(TurnTypes.Turn turn)
        {
            if (turn != TurnTypes.Turn.CPU) { return; }

            _executeActionsCoroutine = StartCoroutine(ExecuteAllActions());
        }
        
        private IEnumerator ExecuteAllActions()
        {
            var actionsCounter = _actionsToExecute.Count;
            for (var i = 0; i < actionsCounter; ++i)
            {
                var action = _actionsToExecute.Dequeue();
                action.Execute();
                --actionsCounter;
                --i;
                
                // Adding some delay to actions for a better gameplay
                yield return new WaitForSeconds(ActionDelay);
            }

            _eventDispatcher.Dispatch(new GameActionsExecutedSignal());
        }
    }
}