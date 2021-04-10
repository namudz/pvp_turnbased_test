using Services;
using Services.Drag;
using UnityEngine;

namespace Heroes.GUI
{
    public class ArrowDirectionView : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private RectTransform _rectTransform;

        private const float MaxHeightMultiplier = 4f; 
        
        private IUserDragHandler _dragHandler;
        private float _baseHeight;

        private void Awake()
        {
            _baseHeight = _rectTransform.sizeDelta.y;
        }

        private void Start()
        {
            ActivateGameObject(false);
            _dragHandler = ServiceLocator.Instance.GetService<IUserDragHandler>();
            _dragHandler.OnDragging += UpdateArrowByDrag;
            _dragHandler.OnEndDragging += HandleDragFinished;
        }

        private void OnEnable()
        {
            EnableCanvas(false);
        }

        public void Show()
        {
            ActivateGameObject(true);
            ResetArrow();
            EnableCanvas(true);
        }

        public void Hide()
        {
            ActivateGameObject(false);
            EnableCanvas(false);
        }

        private void ActivateGameObject(bool isActive)
        {
            // Activating/deactivating the gameObject to only listen to IUserDragHandler events when needed
            gameObject.SetActive(isActive);
        }
        
        private void EnableCanvas(bool isEnabled)
        {
            _canvas.enabled = isEnabled;
        }

        private void ResetArrow()
        {
            _rectTransform.localRotation = Quaternion.Euler(Vector3.zero);
            _rectTransform.localScale = Vector3.one;
            _rectTransform.sizeDelta = new Vector2(_rectTransform.sizeDelta.x, _baseHeight);
        }
        
        private void UpdateArrowByDrag(DragDto dragDto)
        {
            var newHeight = _baseHeight * Mathf.Clamp(MaxHeightMultiplier * dragDto.DistanceFactor, 1f, MaxHeightMultiplier);
            _rectTransform.sizeDelta = new Vector2(_rectTransform.sizeDelta.x, newHeight);
            
            _rectTransform.localRotation = Quaternion.AngleAxis(dragDto.Angle, Vector3.forward);
        }
        
        private void HandleDragFinished(DragDto dragDto)
        {
            UpdateArrowByDrag(dragDto);
            Hide();
        }
    }
}