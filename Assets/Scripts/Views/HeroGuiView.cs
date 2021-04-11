using Heroes;
using Heroes.Health;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class HeroGuiView : MonoBehaviour
    {
        [SerializeField] private Image _barFillImage;
        [SerializeField] private Image _heroPortrait;

        private static Color _aliveColor = Color.white;
        private static Color _deadColor = new Color(1f, 1f, 1f, .5f);
        
        private Hero _hero;
        private IHeroHealth _heroHealth;

        public void InjectDependencies(
            Hero hero,
            IHeroHealth heroHealth)
        {
            _hero = hero;
            _heroHealth = heroHealth;

            _heroHealth.OnDamaged += UpdateBar;
            _heroHealth.OnHealed += UpdateBar;
            _heroHealth.OnDeath += HandleDeath;
        }

        public void ResetOnSpawn()
        {
            UpdateBar(1f);
            _heroPortrait.color = _aliveColor;
        }

        private void UpdateBar(float hpPercentage)
        {
            _barFillImage.fillAmount = hpPercentage;
        }
        
        private void HandleDeath(int heroInstanceId)
        {
            if (_hero.InstanceId != heroInstanceId) { return; }
            UpdateBar(0f);
            _heroPortrait.color = _deadColor;
        }
    }
}