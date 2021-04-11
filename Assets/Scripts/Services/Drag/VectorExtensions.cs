using UnityEngine;

namespace Services.Drag
{
    public static class VectorExtensions
    {
        public static float AngleTo(this Vector2 origin, Vector2 to)
        {
            var direction = to - origin;
            var angle = Mathf.Atan2(direction.x,  direction.y) * Mathf.Rad2Deg;
            return 180f - angle;
        }   
    }
}