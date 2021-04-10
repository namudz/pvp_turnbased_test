using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class HeroActionButtonView : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Image _image;

        private void Awake()
        {
            _button.onClick.AddListener(StartHeroAction);
        }

        public void SetIcon(Sprite sprite)
        {
            gameObject.SetActive(sprite != null);
            _image.sprite = sprite;
        }
        
        private void StartHeroAction()
        {
            Debug.Log("Tell Hero that can execute the action");
        }
    }
}