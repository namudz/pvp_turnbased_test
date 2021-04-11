using System.Collections.Generic;
using Heroes.Controllers;

namespace Heroes.Abilities.Types
{
    public class PushEnemiesAbility : IHeroAbility
    {
        public HeroAbilityType.Type Type => HeroAbilityType.Type.PushEnemies;
        
        public void Execute(IEnumerable<HeroController> targetsControllers)
        {
            throw new System.NotImplementedException();
        }
    }
}