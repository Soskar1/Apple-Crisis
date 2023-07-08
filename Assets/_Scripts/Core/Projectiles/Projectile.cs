using Core.Targets;
using System;
using UnityEngine;

namespace Core.Projectiles
{
    public abstract class Projectile : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private MeshRenderer _renderer;

        public Rigidbody Rigidbody => _rigidbody;
        protected MeshRenderer Renderer => _renderer;

        public Action Landed;
        public Action TargetHit;

        public virtual void VisibleLaunch(Vector3 direction)
        {
            Renderer.enabled = true;
            Launch(direction);
        }

        public virtual void GhostLaunch(Vector3 direction)
        {
            Renderer.enabled = false;
            Launch(direction);
        }

        public abstract void Launch(Vector3 direction);

        public virtual void Deactivate() => gameObject.SetActive(false);

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Target target))
            {
                Deactivate();
                TargetHit?.Invoke();
                Debug.Log("event");
            }
        }
    }
}