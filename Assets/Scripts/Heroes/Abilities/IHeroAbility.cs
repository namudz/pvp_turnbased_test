using Heroes.Abilities.Types;

namespace Heroes.Abilities
{
    public interface IHeroAbility
    {
        HeroAbilityType.Type Type { get; }
        void Execute();
    }
}