using System.Collections.Generic;
using Heroes.Controllers;

namespace Heroes.Abilities.Types
{
    public class PullEnemiesAbility : IHeroAbility
    {
        public HeroAbilityType.Type Type => HeroAbilityType.Type.PullEnemies;
        public void Execute(IEnumerable<HeroController> targetsControllers)
        {
            throw new System.NotImplementedException();
        }
    }
}