using System;
using Heroes.Commands;
using Heroes.GUI;
using Services;
using Services.Drag;
using UnityEngine;

namespace Heroes.Actions
{
    public class MoveActionSimulator : MonoBehaviour, IHeroActionSimulator
    {
        public event Action OnActionSimulated;

        [SerializeField] private HeroGuiController _heroGuiController;
        
        private IUserDragHandler _dragHandler;
        private bool _isSimulating;
        private Action<ICommand> _simulationFinishedCallback;

        private void Start()
        {
            _dragHandler = ServiceLocator.Instance.GetService<IUserDragHandler>();
            _dragHandler.OnEndDragging += HandleDragFinished;
        }

        public void CanSimulate(Action<ICommand> onSimulationFinished)
        {
            _simulationFinishedCallback = onSimulationFinished;
            _isSimulating = true;
            _dragHandler.StartHandlingDrag();
            _heroGuiController.ShowDirectionArrow();
        }
        
        private void HandleDragFinished(DragDto dragDto)
        {
            _simulationFinishedCallback?.Invoke(new MoveCommand(dragDto));
        }
    }
}