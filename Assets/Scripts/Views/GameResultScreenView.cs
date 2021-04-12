using Game;
using Services;
using Services.EventDispatcher;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class GameResultScreenView : MonoBehaviour
    {
        [SerializeField] private Canvas _myCanvas;
        [SerializeField] private TextMeshProUGUI _teamWinnerText;

        private void Start()
        {
            var eventDispatcher = ServiceLocator.Instance.GetService<IEventDispatcher>();
            eventDispatcher.Subscribe<GameOverSignal>(HandleGameOver);
            eventDispatcher.Subscribe<GameStartSignal>(HandleGameStart);
            Hide();
        }

        private void HandleGameStart(ISignal signal)
        {
            Hide();
        }

        private void HandleGameOver(ISignal iSignal)
        {
            var signal = iSignal as GameOverSignal;
            _teamWinnerText.SetText(signal.TeamWinner.ToString());
            Show();
        }

        private void Show()
        {
            _myCanvas.enabled = true;
        }

        private void Hide()
        {
            _myCanvas.enabled = false;
        }
    }
}