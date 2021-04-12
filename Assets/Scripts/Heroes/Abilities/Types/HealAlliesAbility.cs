using System.Collections.Generic;
using Heroes.Controllers;

namespace Heroes.Abilities.Types
{
    public class HealAlliesAbility : IHeroAbility
    {
        public HeroAbilityType.Type Type => HeroAbilityType.Type.HealAllies;
        private float _healPoints;

        public HealAlliesAbility(float healPoints)
        {
            _healPoints = healPoints;
        }

        public void Execute(IEnumerable<HeroController> targetsControllers)
        {
            foreach (var target in targetsControllers)
            {
                target.HeroHealth.Heal(_healPoints);
            }
        }
    }
}