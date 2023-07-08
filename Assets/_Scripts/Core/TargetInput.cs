using UnityEngine;

namespace Core
{
    public class Input
    {
        private Controls _controls;

        public Controls Controls => _controls;

        public Input() => _controls = new Controls();

        public void Enable() => Controls.Enable();
        public void Disable() => Controls.Disable();

        public Vector2 MovementInput => Controls.Target.Movement.ReadValue<Vector2>();
    }
}