using System.Collections.Generic;
using Heroes.Abilities.Types;
using Heroes.Controllers;

namespace Heroes.Abilities
{
    public interface IHeroAbility
    {
        HeroAbilityType.Type Type { get; }
        void Execute(IEnumerable<HeroController> targetsControllers);
    }
}