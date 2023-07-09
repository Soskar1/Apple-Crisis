using Core.Targets;
using UnityEngine;

namespace Core
{
    public class Honey : MonoBehaviour
    {
        [SerializeField] private float _maxSpeedInHoney;
        private float _initialTargetSpeed;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IMovement movement))
            {
                if (movement.MaxMoveSpeed != _maxSpeedInHoney)
                {
                    _initialTargetSpeed = movement.MaxMoveSpeed;
                    movement.MaxMoveSpeed = _maxSpeedInHoney;
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out IMovement movement))
                movement.MaxMoveSpeed = _initialTargetSpeed;
        }
    }
}