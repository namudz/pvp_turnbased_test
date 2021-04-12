using Heroes.Actions;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class HeroActionButtonView : MonoBehaviour
    {
        [SerializeField] private HeroActionsPanelView _heroActionsPanelView;
        [SerializeField] private Button _button;
        [SerializeField] private Image _image;
        
        private HeroActionType.Type _actionType;

        private void Awake()
        {
            _button.onClick.AddListener(StartHeroActionSimulation);
        }

        public void SetActionType(HeroActionType.Type actionType)
        {
            _actionType = actionType;
        }

        public void SetIcon(Sprite sprite)
        {
            gameObject.SetActive(sprite != null);
            _image.sprite = sprite;
        }
        
        private void StartHeroActionSimulation()
        {
            _heroActionsPanelView.SelectedHeroAction(_actionType);
        }
    }
}