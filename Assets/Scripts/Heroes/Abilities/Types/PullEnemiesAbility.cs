using System.Collections.Generic;
using Heroes.Controllers;
using UnityEngine;

namespace Heroes.Abilities.Types
{
    public class PullEnemiesAbility : IHeroAbility
    {
        public HeroAbilityType.Type Type => HeroAbilityType.Type.PullEnemies;
        private readonly float _force;
        private readonly float _range;
        private Vector3 _casterPosition;

        public PullEnemiesAbility(float force, float range)
        {
            _force = force;
            _range = range;
        }
        
        public void SetCasterPosition(Vector3 casterPosition)
        {
            _casterPosition = casterPosition;
        }
        
        public void Execute(IEnumerable<HeroController> targetsControllers)
        {
            foreach (var target in targetsControllers)
            {
                target.HeroMovement.Pull(_casterPosition, _force, _range);
            }
        }
    }
}