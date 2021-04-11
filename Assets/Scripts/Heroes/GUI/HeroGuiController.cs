using UnityEngine;
using UnityEngine.UI;

namespace Heroes.GUI
{
    public class HeroGuiController : MonoBehaviour
    {
        [SerializeField] private ArrowDirectionView _view;
        [Header("Selectable circle")]
        [SerializeField] private Image _selectableCircle;
        [SerializeField] private Color _defaultSelectableCircleColor;
        [SerializeField] private Color _highlightSelectableCircleColor;

        public void ShowDirectionArrow()
        {
            _view.Show();
        }

        public void ShowSelectableCircle()
        {
            _selectableCircle.enabled = true;
            _selectableCircle.color = _defaultSelectableCircleColor;
        }

        public void HideSelectableCircle()
        {
            _selectableCircle.enabled = false;
        }

        public void HighlightSelectableCircle()
        {
            _selectableCircle.color = _highlightSelectableCircleColor;
        }
    }
}