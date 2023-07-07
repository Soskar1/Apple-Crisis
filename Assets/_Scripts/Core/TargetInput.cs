using UnityEngine;

namespace Core
{
    public class TargetInput : MonoBehaviour
    {
        public Controls Controls { get; private set; }

        private void Awake() => Controls = new Controls();
        public void OnEnable() => Controls.Enable();
        public void OnDisable() => Controls.Disable();

        public Vector2 MovementInput => Controls.Target.Movement.ReadValue<Vector2>();
    }
}