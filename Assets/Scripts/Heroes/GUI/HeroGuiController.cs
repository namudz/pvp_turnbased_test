using UnityEngine;

namespace Heroes.GUI
{
    public class HeroGuiController : MonoBehaviour
    {
        [SerializeField] private ArrowDirectionView _view;

        public void ShowDirectionArrow()
        {
            _view.Show();
        }
    }
}