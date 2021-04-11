﻿using System;
using System.Collections.Generic;
using Heroes.Animator;
using Heroes.Controllers;
using UnityEngine;

namespace Heroes.Abilities
{
    public class HeroAbilityController : MonoBehaviour
    {
        [SerializeField] private HeroAnimatorController _animatorController;
        [SerializeField] private SphereCollider _detectionCollider;
        
        private Hero _hero;
        private HeroTypes.Team _targetTeam;

        private List<HeroController> _targetsControllers = new List<HeroController>();

        private void Awake()
        {
            _detectionCollider.enabled = false;
        }

        public void InjectDependencies(Hero hero)
        {
            _hero = hero;
        }

        public void Cast(HeroTypes.Team targetTeam)
        {
            _targetTeam = targetTeam;
            _detectionCollider.enabled = true;
            _animatorController.CastAbility(ApplyAbility);
        }

        public void CastPushEnemies()
        {
            
        }

        public void CastPullEnemies()
        {
            
        }
        
        private void OnTriggerEnter(Collider other)
        {
            var targetController = other.GetComponent<HeroController>();
            if (targetController == null
                || targetController.HeroInstanceId == _hero.InstanceId
                || _targetTeam != targetController.HeroTeam)
            {
                return;
            }
            
            _targetsControllers.Add(targetController);
            _detectionCollider.enabled = false;
        }

        private void ApplyAbility()
        {
            _hero.Ability?.Execute(_targetsControllers);
        }
    }
}