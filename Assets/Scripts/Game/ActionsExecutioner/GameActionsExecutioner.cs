using System.Collections.Generic;
using Heroes.Commands;

namespace Game.ActionsExecutioner
{
    public class GameActionsExecutioner : IGameActionsExecutioner
    {
        private Queue<ICommand> _actionsToExecute;

        public GameActionsExecutioner()
        {
            _actionsToExecute = new Queue<ICommand>();
        }
        
        public void AddAction(ICommand command)
        {
            _actionsToExecute.Enqueue(command);
        }

        public void ExecuteAllActions()
        {
            var actionsCounter = _actionsToExecute.Count;
            for (var i = 0; i < actionsCounter; ++i)
            {
                var action = _actionsToExecute.Dequeue();
                action.Execute();
                --actionsCounter;
            }
        }

        public void Reset()
        {
            _actionsToExecute.Clear();
        } 
    }
}