using UnityEngine;

namespace Core.Projectiles
{
    public class Arrow : Projectile
    {
        [SerializeField] private Rigidbody _rigidbody;

        public override void Launch(Vector3 direction) => _rigidbody.AddForce(direction, ForceMode.Impulse);
    }
}