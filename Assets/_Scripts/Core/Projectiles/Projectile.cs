using Core.Targets;
using System;
using UnityEngine;

namespace Core.Projectiles
{
    public abstract class Projectile : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private GameObject _visual;

        public Rigidbody Rigidbody => _rigidbody;

        public Action Landed;

        public virtual void VisibleLaunch(Vector3 direction)
        {
            _visual.SetActive(true);
            Launch(direction);
        }

        public virtual void GhostLaunch(Vector3 direction)
        {
            _visual.SetActive(false);
            Launch(direction);
        }

        public abstract void Launch(Vector3 direction);

        public virtual void Deactivate() => gameObject.SetActive(false);

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Target target))
                Level.NextLevel();
        }
    }
}