using UnityEngine;

namespace Core.Projectiles
{
    public class Arrow : Projectile
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Vector3 _direction;

        private void Start() => Launch(_direction);

        public override void Launch(Vector3 direction)
        {
            _rigidbody.AddForce(_direction, ForceMode.Impulse);
        }
    }
}