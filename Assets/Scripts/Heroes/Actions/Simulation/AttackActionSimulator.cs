using System;
using Heroes.Attacks;
using Heroes.Attacks.Types;
using Heroes.Commands;
using Heroes.Commands.Attack;
using Heroes.GUI;
using Services;
using Services.Drag;
using UnityEngine;

namespace Heroes.Actions.Simulation
{
    public class AttackActionSimulator : MonoBehaviour, IHeroActionSimulator
    {
        public event Action OnActionSimulated;
        
        [SerializeField] private HeroAttackController _heroAttackController;
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
                    var command = new AttackMeleeCommand(_hero, _heroAttackController);
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

            _dragHandler.OnEndDragging -= HandleDragFinished;
            var command = new AttackRangeCommand(_hero, _heroAttackController, dragDto);
            FinishSimulation(command);
        }

        private void FinishSimulation(ICommand command)
        {
            _simulationFinishedCallback?.Invoke(command);
            _isSimulating = false;
        }
    }
}