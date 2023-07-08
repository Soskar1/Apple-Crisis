using System;
using UnityEngine;

namespace Core.Projectiles
{
    public abstract class Projectile : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _renderer;
        protected MeshRenderer Renderer => _renderer;

        private bool _isGhost = false;
        public bool IsGhost => _isGhost;

        public Action Landed;

        public virtual void VisibleLaunch(Vector3 direction)
        {
            Renderer.enabled = true;
            _isGhost = false;
            Launch(direction);
        }

        public virtual void GhostLaunch(Vector3 direction)
        {
            Renderer.enabled = false;
            _isGhost = true;
            Launch(direction);
        }

        public abstract void Launch(Vector3 direction);

        public virtual void Deactivate()
        {
            gameObject.SetActive(false);
        }
    }
}