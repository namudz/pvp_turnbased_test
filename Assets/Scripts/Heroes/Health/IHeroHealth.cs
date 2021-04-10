namespace Heroes.Health
{
    public interface IHeroHealth
    {
        event System.Action<float> OnDamaged;
        event System.Action<int> OnDeath;
        void Damage (float damage);
    }
}