namespace Heroes.Attacks
{
    public interface IHeroAttack
    {
        float AttackPoints { get; }
        float AttackRange { get; }
        void Attack();
    }
}