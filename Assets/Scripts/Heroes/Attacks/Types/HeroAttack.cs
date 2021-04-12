namespace Heroes.Attacks.Types
{
    public abstract class HeroAttack : IHeroAttack
    {
        public abstract HeroAttackType.Type Type { get; }
        public float AttackPoints { get; }

        public HeroAttack(float attackPoints)
        {
            AttackPoints = attackPoints;
        }
    }
}