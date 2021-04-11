using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Services.Drag
{
    public class DragTest : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public TextMeshProUGUI _startPosText;
        public TextMeshProUGUI _currentText;
        public TextMeshProUGUI _angleText;
        public Transform _prefabTransform;
        public Transform _prefabTransform2;

        private Vector2 _startPoint;
        private Vector2 _currentPoint;
        
        public void OnBeginDrag(PointerEventData eventData)
        {
            _startPoint = eventData.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            _currentPoint = eventData.position;
            UpdateDebugViews();
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _currentPoint = eventData.position;
        }

        private void UpdateDebugViews()
        {
            _startPosText.SetText(_startPoint.ToString());
            _currentText.SetText(_currentPoint.ToString());
            
            var angle = GetAngle();
            _angleText.SetText(angle.ToString());
            
            _prefabTransform.localRotation = Quaternion.AngleAxis(angle, Vector3.up);
            _prefabTransform2.localRotation = Quaternion.AngleAxis(angle, Vector3.up);
            
        }

        private float GetAngle()
        {
            /*var dir = _currentPoint - _startPoint;
            return Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;*/
            //return Vector2.SignedAngle(_startPoint, _currentPoint);
            return _startPoint.AngleTo(_currentPoint);
        }
    }

    public static class VectorExtensions
    {
        public static float AngleTo(this Vector2 this_, Vector2 to)
        {
            Vector2 direction = to - this_;
            float angle = Mathf.Atan2(direction.x,  direction.y) * Mathf.Rad2Deg;
            if (angle < 0f) angle += 360f;
            return angle;
        }   
    }
}