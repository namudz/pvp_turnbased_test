using Heroes.Abilities;
using Heroes.Abilities.Types;
using Heroes.Attacks;
using Heroes.Attacks.Types;
using Heroes.Health;
using JetBrains.Annotations;

namespace Heroes
{
    public class Hero
    {
        public HealthPoints HealthPoints;
        public float MovementRange;
        public IHeroAttack Attack;
        [CanBeNull] public IHeroAbility Ability;

        public Hero(HeroStatsConfig stats)
        {
            HealthPoints = new HealthPoints(stats.HealthPoints);
            MovementRange = stats.MovementRange;
            Attack = AttackFactory.GetAttack(stats.AttackConfig);
            Ability = AbilityFactory.GetAbility(stats.AbilityConfig);
        }
    }
}