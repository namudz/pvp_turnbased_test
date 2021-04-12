using System.Collections;
using System.Collections.Generic;
using Game.Turn;
using Game.Turn.Dealer;
using Heroes.Actions;
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
        private List<ICommand> _actionsToExecute;
        private ICommand _currentActionExecuting;

        public void InjectDependencies(ITurnDealer turnDealer, IEventDispatcher eventDispatcher)
        {
            _turnDealer = turnDealer;
            _eventDispatcher = eventDispatcher;
            _actionsToExecute = new List<ICommand>();

            _turnDealer.OnTurnChanged += HandleTurnChanged;
        }

        public void AddAction(ICommand command)
        {
            _actionsToExecute.Add(command);
        }

        public void ResetActions()
        {
            _actionsToExecute.Clear();
        }
        
        private void HandleTurnChanged(TurnTypes.Turn turn)
        {
            if (turn != TurnTypes.Turn.CPU) { return; }

            OrderActions();
            ExecuteNextAction();
        }

        private void OrderActions()
        {
            _actionsToExecute.Sort((p, q) => p.Type.CompareTo(q.Type));
        }

        private IEnumerator ExecuteAllActions()
        {
            /*var actionsCounter = _actionsToExecute.Count;
            for (var i = 0; i < actionsCounter; ++i)
            {
                var action = _actionsToExecute.Dequeue();
                action.Execute();
                --actionsCounter;
                --i;
                
                // Adding some delay to actions for a better gameplay
                yield return new WaitForSeconds(ActionDelay);
            }

            _eventDispatcher.Dispatch(new GameActionsExecutedSignal());*/
            yield return null;
        }

        private void ExecuteNextAction()
        {
            if (_currentActionExecuting != null)
            {
                _currentActionExecuting.OnCompleted -= ExecuteNextAction;
            }
            
            if (_actionsToExecute.Count == 0)
            {
                _eventDispatcher.Dispatch(new GameActionsExecutedSignal());
                return;
            }

            _currentActionExecuting = _actionsToExecute[0];
            _actionsToExecute.RemoveAt(0);
            _currentActionExecuting.OnCompleted += ExecuteNextAction;
            _currentActionExecuting.Execute();
        }

        private void ExecuteActionsType(HeroActionType.Type actionType)
        {
            var actionsCounter = _actionsToExecute.Count;
            for (var i = 0; i < actionsCounter; ++i)
            {
                var action = _actionsToExecute[i];
                if(action.Type != HeroActionType.Type.Move){ break;}
                
                action.Execute();
                _actionsToExecute.RemoveAt(i);
                --actionsCounter;
                --i;
            }
        }
    }
}