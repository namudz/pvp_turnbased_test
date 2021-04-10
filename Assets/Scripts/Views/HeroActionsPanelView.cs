using Heroes;
using Heroes.Selector;
using Services;
using Services.EventDispatcher;
using Services.ImageBank;
using UnityEngine;

namespace Views
{
    public class HeroActionsPanelView : MonoBehaviour
    {
        [Header("Panel")]
        [SerializeField] private Canvas _myCanvas;
        [Header("Action Buttons")]
        [SerializeField] private HeroActionButtonView _moveActionButton;
        [SerializeField] private HeroActionButtonView _attackActionButton;
        [SerializeField] private HeroActionButtonView _abilityActionButton;

        private IEventDispatcher _eventDispatcher;
        private IImageBank _imageBank;

        private void Awake()
        {
            ServiceLocator.Instance.RegisterService(this);
            EnableCanvas(false);
        }

        private void Start()
        {
            _imageBank = ServiceLocator.Instance.GetService<IImageBank>();
        }

        public void InjectDependencies(IEventDispatcher eventDispatcher)
        {
            _eventDispatcher = eventDispatcher;
            _eventDispatcher.Subscribe<HeroSelectedSignal>(ShowPanel);
        }

        private void ShowPanel(ISignal iSignal)
        {
            var signal = iSignal as HeroSelectedSignal;
            EnableCanvas(true);
            UpdateActionButtons(signal.Hero);
        }

        private void EnableCanvas(bool isEnabled)
        {
            _myCanvas.enabled = isEnabled;
        }
        
        private void UpdateActionButtons(Hero hero)
        {
            _moveActionButton.SetIcon(_imageBank.GetMoveIcon());
            _attackActionButton.SetIcon(_imageBank.GetAttackIcon(hero.Attack.Type));
            _abilityActionButton.SetIcon(_imageBank.GetAbilityIcon(hero.Ability?.Type));
        }
    }
}