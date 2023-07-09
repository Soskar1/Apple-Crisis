using UnityEngine;

namespace Core.Targets
{
    public interface IMovement
    {
        public float MaxMoveSpeed { get; set; }

        void Move(Vector3 direction);
    }
}