using System;
using Game.ActionsExecutioner;
using Heroes.Actions.Simulation;
using Heroes.Commands;
using Services.Drag;
using UnityEngine;

namespace Heroes.Actions
{
    public class HeroActionController : MonoBehaviour, IHeroActionController
    {
        public event Action OnActionSimulationFinished;
        public event Action OnActionStartSimulation;

        [SerializeField] private MoveActionSimulator _moveSimulator;
        [SerializeField] private AttackActionSimulator _attackSimulator;
        [SerializeField] private AbilityActionSimulator _abilitySimulator;
        
        private Hero _hero;
        private IUserDragHandler _dragHandler;
        private IGameActionsExecutioner _gameActionsExecutioner;

        public void InjectDependencies(Hero hero, IGameActionsExecutioner gameActionsExecutioner)
        {
            _hero = hero;
            _gameActionsExecutioner = gameActionsExecutioner;
            
            _moveSimulator.InjectDependencies(_hero);
            _attackSimulator.InjectDependencies(_hero);
            _abilitySimulator.InjectDependencies(_hero);
            
            _hero.OnStartSimulatingAction += StartSimulatingAction;
        }

        private void StartSimulatingAction(HeroActionType.Type actionType)
        {
            switch (actionType)
            {
                case HeroActionType.Type.Move:
                    _moveSimulator.CanSimulate(OnSimulationFinished);
                    break;
                case HeroActionType.Type.Attack:
                    _attackSimulator.CanSimulate(OnSimulationFinished);
                    break;
                case HeroActionType.Type.Ability:
                    _abilitySimulator.CanSimulate(OnSimulationFinished);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(actionType), actionType, null);
            }
            OnActionStartSimulation?.Invoke();
        }

        private void OnSimulationFinished(ICommand command)
        {
            _gameActionsExecutioner.AddAction(command);
            OnActionSimulationFinished?.Invoke();
        }
    }
}