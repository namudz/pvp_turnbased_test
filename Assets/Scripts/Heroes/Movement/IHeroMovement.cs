using UnityEngine;

namespace Heroes.Movement
{
    public interface IHeroMovement
    {
        void Move(float angle, float forceMultiplier);
        void Pull(Vector3 casterPosition, float force, float range);
        void Push(Vector3 casterPosition, float force, float range);
    }
}