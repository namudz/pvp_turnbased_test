using System.Collections.Generic;
using Heroes.Controllers;

namespace Heroes.Abilities.Types
{
    public class PushEnemiesAbility : IHeroAbility
    {
        public HeroAbilityType.Type Type => HeroAbilityType.Type.PushEnemies;
        private readonly float _force;

        public PushEnemiesAbility(float force)
        {
            _force = force;
        }
        
        public void Execute(IEnumerable<HeroController> targetsControllers)
        {
            foreach (var target in targetsControllers)
            {
                // TODO: Push on correct direction
                target.HeroMovement.Move(0f, _force);
            }
        }
    }
}