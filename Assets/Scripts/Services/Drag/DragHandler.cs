using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Services.Drag
{
    public class DragHandler : MonoBehaviour, IUserDragHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public event Action OnBeginDragging;
        public event Action<DragDto> OnDragging;
        public event Action<DragDto> OnEndDragging;
        
        [SerializeField] private Image _image;
        [SerializeField] private float _maxDragDistance = 200f;

        private Vector2 _startDragPoint;
        private Vector2 _currentDragPoint;
        private DragDto _dragDto;

        private void Awake()
        {
            ServiceLocator.Instance.RegisterService<IUserDragHandler>(this);
        }

        public void StartHandlingDrag()
        {
            _image.enabled = true;
        }

        public void StopHandlingDrag()
        {
            _image.enabled = false;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _startDragPoint = eventData.position;
            OnBeginDragging?.Invoke();
        }
        
        public void OnDrag(PointerEventData eventData)
        {
            _currentDragPoint = eventData.position;
            UpdateDragDto();
            OnDragging?.Invoke(_dragDto);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _currentDragPoint = eventData.position;
            UpdateDragDto();
            OnEndDragging?.Invoke(_dragDto);
        }

        private void UpdateDragDto()
        {
            var distanceFactor = Vector2.Distance(_startDragPoint, _currentDragPoint) / _maxDragDistance;
            distanceFactor = Mathf.Clamp01(distanceFactor);
            _dragDto.DistanceFactor = distanceFactor;

            _dragDto.Angle = _startDragPoint.AngleTo(_currentDragPoint);
        }
    }
}