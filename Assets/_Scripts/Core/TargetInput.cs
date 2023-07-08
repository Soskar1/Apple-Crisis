using UnityEngine;

namespace Core
{
    public class TargetInput : MonoBehaviour
    {
        private Controls _controls;

        public Controls Controls
        {
            get
            {
                if (_controls == null)
                    _controls = new Controls();

                return _controls;
            }
        }

        public void OnEnable() => Controls.Enable();
        public void OnDisable() => Controls.Disable();

        public Vector2 MovementInput => Controls.Target.Movement.ReadValue<Vector2>();
    }
}