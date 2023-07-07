using UnityEngine;

namespace Core.Targets
{
    public class ThirdPersonRotation : MonoBehaviour
    {
        [SerializeField] private float _turnSmoothTime = 0.1f;
        private float _turnSmoothVelocity = 1f;

        public void Rotate(float targetRotY)
        {
            float rotY = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotY, ref _turnSmoothVelocity, _turnSmoothTime);
            transform.rotation = Quaternion.Euler(0.0f, rotY, 0.0f);
        }
    }
}