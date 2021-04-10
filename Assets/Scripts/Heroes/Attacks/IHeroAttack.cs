using Heroes.Attacks.Types;

namespace Heroes.Attacks
{
    public interface IHeroAttack
    {
        HeroAttackType.Type Type { get; }
        float AttackPoints { get; }
        float AttackRange { get; }
        void Attack();
    }
}