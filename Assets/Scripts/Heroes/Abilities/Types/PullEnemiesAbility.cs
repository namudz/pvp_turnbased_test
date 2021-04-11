using System.Collections.Generic;
using Heroes.Controllers;

namespace Heroes.Abilities.Types
{
    public class PullEnemiesAbility : IHeroAbility
    {
        public HeroAbilityType.Type Type => HeroAbilityType.Type.PullEnemies;
        private readonly float _force;

        public PullEnemiesAbility(float force)
        {
            _force = force;
        }
        
        public void Execute(IEnumerable<HeroController> targetsControllers)
        {
            foreach (var target in targetsControllers)
            {
                // TODO: Pull on correct direction
                target.HeroMovement.Move(0f, _force);
            }
        }
    }
}