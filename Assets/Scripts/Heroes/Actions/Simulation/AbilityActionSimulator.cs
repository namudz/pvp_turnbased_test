﻿using System;
using Heroes.Abilities;
using Heroes.Abilities.Types;
using Heroes.Commands;
using Heroes.Commands.Ability;
using UnityEngine;

namespace Heroes.Actions.Simulation
{
    public class AbilityActionSimulator : MonoBehaviour, IHeroActionSimulator
    {
        public event Action OnActionSimulated;
        
        [SerializeField] private HeroAbilityController _heroAbilityController;

        private Hero _hero;
        private bool _isSimulating;
        private Action<ICommand> _simulationFinishedCallback;

        public void InjectDependencies(Hero hero)
        {
            _hero = hero;
        }

        public void CanSimulate(Action<ICommand> onSimulationFinished)
        {
            if (_hero.Ability == null) { return; }
            
            _simulationFinishedCallback = onSimulationFinished;
            
            ICommand command = null;
            switch (_hero.Ability.Type)
            {
                case HeroAbilityType.Type.HealAllies:
                    command = new AbilityHealAlliesCommand(_hero, _heroAbilityController);
                    break;
                case HeroAbilityType.Type.PullEnemies:
                    command = new AbilityPullEnemiesCommand(_hero);
                    break;
                case HeroAbilityType.Type.PushEnemies:
                    command = new AbilityPushEnemiesCommand(_hero);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            FinishSimulation(command);
        }
        
        private void FinishSimulation(ICommand command)
        {
            _simulationFinishedCallback?.Invoke(command);
            _isSimulating = false;
        }
    }
}