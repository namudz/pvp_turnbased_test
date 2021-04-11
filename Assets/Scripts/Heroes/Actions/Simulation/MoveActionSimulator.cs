﻿using System;
using Heroes.Commands;
using Heroes.GUI;
using Services;
using Services.Drag;
using UnityEngine;

namespace Heroes.Actions.Simulation
{
    public class MoveActionSimulator : MonoBehaviour, IHeroActionSimulator
    {
        public event Action OnActionSimulated;

        [SerializeField] private HeroActionController _heroActionController;
        [SerializeField] private HeroGuiController _heroGuiController;
        
        private IUserDragHandler _dragHandler;
        private Hero _hero;
        private bool _isSimulating;
        private Action<ICommand> _simulationFinishedCallback;

        private void Start()
        {
            _dragHandler = ServiceLocator.Instance.GetService<IUserDragHandler>();
            _dragHandler.OnEndDragging += HandleDragFinished;
        }

        public void InjectDependencies(Hero hero)
        {
            _hero = hero;
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
            if (!_isSimulating) { return; }

            // TODO: which data would I need to execute it?
            var command = new MoveCommand(_heroActionController, dragDto);
            _simulationFinishedCallback?.Invoke(command);
            _isSimulating = false;
        }
    }
}