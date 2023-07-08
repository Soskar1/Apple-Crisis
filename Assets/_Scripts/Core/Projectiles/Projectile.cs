using UnityEngine;

namespace Core.Projectiles
{
    public abstract class Projectile : MonoBehaviour
    {
        public abstract void Launch(Vector3 direction);

        private void OnCollisionEnter(Collision collision) => Destroy(gameObject);
    }
}