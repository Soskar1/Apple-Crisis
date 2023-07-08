using Core.Projectiles;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Core.Targets
{
    public class Target : MonoBehaviour
    {
        [SerializeField] private TargetInput _input;
        [SerializeField] private ThirdPersonRotation _rotation;
        [SerializeField] private Jumping _jumping;
        [SerializeField] private GroundCheck _groundCheck;
        private Camera _camera;
        private IMovement _movement;

        private Vector3 _targetMovementDirection;

        private void Awake()
        {
            _movement = GetComponent<IMovement>();
            _camera = Camera.main;
        }

        private void OnEnable() => _input.Controls.Target.Jump.performed += Jump;
        private void OnDisable() => _input.Controls.Target.Jump.performed -= Jump;

        private void Update()
        {
            float targetRotY = Mathf.Atan2(_input.MovementInput.x, _input.MovementInput.y) * Mathf.Rad2Deg + _camera.transform.eulerAngles.y;
            _rotation.Rotate(targetRotY);
            _targetMovementDirection = Quaternion.Euler(0.0f, targetRotY, 0.0f) * Vector3.forward;
        }

        private void FixedUpdate()
        {
            Vector3 movementDirection = _input.MovementInput.magnitude == 0 ? Vector3.zero : _targetMovementDirection;
            _movement.Move(movementDirection);
        }

        private void Jump(InputAction.CallbackContext ctx)
        {
            if (_groundCheck.CheckForGround())
                _jumping.Jump();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Projectile projectile))
            {
                projectile.Deactivate();
                Debug.Log("event");
            }
        }
    }
}