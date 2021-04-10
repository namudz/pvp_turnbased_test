using Heroes.Abilities;
using Heroes.Attacks;
using Heroes.Health;

namespace Heroes
{
    public class Heroe
    {
        public HealthPoints HealthPoints;
        public float MovementRange;
        public IHeroAttack Attack;
        public IHeroAbility Ability;

        public Heroe(HeroStatsConfig stats)
        {
            HealthPoints = new HealthPoints(stats.HealthPoints);
            MovementRange = stats.MovementRange;
            // TODO: Get pertinent IHeroAttack & IHeroAbility from Factories
            Attack = null;
            Ability = null;
        }
    }
}