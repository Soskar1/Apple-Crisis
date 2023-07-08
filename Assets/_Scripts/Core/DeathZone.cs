using Core.Projectiles;
using Core.Targets;
using UnityEngine;
using Zenject;

namespace Core
{
    public class DeathZone : MonoBehaviour
    {
        private ProjectileLauncher _projectileLauncher;

        [Inject]
        private void Construct(ProjectileLauncher projectileLauncher)
        {
            _projectileLauncher = projectileLauncher;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Projectile projectile))
                _projectileLauncher.GhostLaunch();

            if (other.TryGetComponent(out Target target))
                Debug.Log("Game Over");
        }
    }
}