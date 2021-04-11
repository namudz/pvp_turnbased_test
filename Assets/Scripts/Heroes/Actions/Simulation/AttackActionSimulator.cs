using System;
using Heroes.Attacks.Types;
using Heroes.Commands;
using Heroes.GUI;
using Services;
using Services.Drag;
using UnityEngine;

namespace Heroes.Actions.Simulation
{
    public class AttackActionSimulator : MonoBehaviour, IHeroActionSimulator
    {
        public event Action OnActionSimulated;
        
        [SerializeField] private HeroActionController _heroActionController;
        [SerializeField] private HeroGuiController _heroGuiController;

        private Hero _hero;
        private IUserDragHandler _dragHandler;
        private bool _isSimulating;
        private Action<ICommand> _simulationFinishedCallback;

        private void Start()
        {
            _dragHandler = ServiceLocator.Instance.GetService<IUserDragHandler>();
        }

        public void InjectDependencies(Hero hero)
        {
            _hero = hero;
        }

        public void CanSimulate(Action<ICommand> onSimulationFinished)
        {
            _simulationFinishedCallback = onSimulationFinished;
            switch (_hero.Attack.Type)
            {
                case HeroAttackType.Type.Melee:
                    var command = new AttackMeleeCommand(_heroActionController);
                    FinishSimulation(command);
                    return;
                
                case HeroAttackType.Type.Range:
                    _isSimulating = true;
                    _dragHandler.OnEndDragging += HandleDragFinished;
                    _dragHandler.StartHandlingDrag();
                    _heroGuiController.ShowDirectionArrow();
                    return;
            }
        }
        
        private void HandleDragFinished(DragDto dragDto)
        {
            if (!_isSimulating) { return; }

            // TODO: which data would I need to execute it?
            _dragHandler.OnEndDragging -= HandleDragFinished;
            var command = new AttackRangeCommand(_heroActionController, dragDto);
            FinishSimulation(command);
        }

        private void FinishSimulation(ICommand command)
        {
            _simulationFinishedCallback?.Invoke(command);
            _isSimulating = false;
        }
    }
}