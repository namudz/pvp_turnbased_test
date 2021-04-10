using System;
using Heroes.Commands;
using Services.Drag;
using UnityEngine;

namespace Heroes.Actions
{
    public class HeroActionController : MonoBehaviour, IHeroActionController
    {
        public event Action OnActionSimulated;

        [SerializeField] private MoveActionSimulator _moveSimulator;
        [SerializeField] private AttackActionSimulator _attackSimulator;
        [SerializeField] private AbilityActionSimulator _abilitySimulator;
        
        public ICommand ActionCommand { get; private set; }
        
        private Hero _hero;
        private IUserDragHandler _dragHandler;

        public void InjectDependencies(Hero hero)
        {
            _hero = hero;

            _hero.OnStartSimulatingAction += StartSimulatingAction;
        }

        private void StartSimulatingAction(HeroActionType.Type actionType)
        {
            switch (actionType)
            {
                case HeroActionType.Type.Move:
                    _moveSimulator.CanSimulate(GetActionCommand);
                    break;
                case HeroActionType.Type.Attack:
                    _attackSimulator.CanSimulate(GetActionCommand);
                    break;
                case HeroActionType.Type.Ability:
                    _abilitySimulator.CanSimulate(GetActionCommand);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(actionType), actionType, null);
            }
        }

        private void GetActionCommand(ICommand command)
        {
            ActionCommand = command;
        }
    }
}