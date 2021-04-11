using System;

namespace Heroes.Health
{
    public class HeroHealth : IHeroHealth
    {
        public event Action<float> OnDamaged;
        public event Action<float> OnHealed;
        public event Action<int> OnDeath;
        private readonly Hero _hero;

        public HeroHealth(Hero hero)
        {
            _hero = hero;
        }

        public void Damage(float damage)
        {
            _hero.HealthPoints.Current -= damage;
            if (_hero.HealthPoints.Current <= 0)
            {
                _hero.HealthPoints.Current = 0;
                LaunchDeathEvent();
                return;
            }
            LaunchDamagedEvent();
        }

        public void Heal(float hp)
        {
            _hero.HealthPoints.Current += hp;
            LaunchHealedEvent();
        }

        private void LaunchDamagedEvent()
        {
            OnDamaged?.Invoke(_hero.HealthPoints.GetCurrentHealthPercentage());
        }
        
        private void LaunchHealedEvent()
        {
            OnHealed?.Invoke(_hero.HealthPoints.GetCurrentHealthPercentage());
        }

        private void LaunchDeathEvent()
        {
            OnDeath?.Invoke(_hero.InstanceId);
        }
    }
}