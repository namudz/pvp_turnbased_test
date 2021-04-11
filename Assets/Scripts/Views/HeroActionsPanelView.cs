using Heroes;
using Heroes.Actions;
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
        private Hero _selectedHero;

        private void Awake()
        {
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
        
        public void SelectedHeroAction(HeroActionType.Type actionType)
        {
            _selectedHero?.StartSimulatingAction(actionType);
            EnableCanvas(false);
        }

        private void ShowPanel(ISignal iSignal)
        {
            var signal = iSignal as HeroSelectedSignal;
            _selectedHero = signal.Hero;
            EnableCanvas(true);
            UpdateActionButtons(_selectedHero);
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