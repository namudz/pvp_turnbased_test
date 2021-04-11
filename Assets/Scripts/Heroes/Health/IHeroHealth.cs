using System;

namespace Heroes.Health
{
    public interface IHeroHealth
    {
        event Action<float> OnDamaged;
        event Action<float> OnHealed;
        event Action<int> OnDeath;
        void Damage (float damage);
        void Heal (float hp);
    }
}