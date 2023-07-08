using UnityEngine;

namespace Core.Projectiles
{
    public class ProjectileLauncher : MonoBehaviour
    {
        [SerializeField] private Projectile _projectilePrefab;
        [SerializeField] private Transform _spawnPosition;

        [SerializeField] private Vector3 _maxProjectileLaunchForce;
        [SerializeField] private Vector3 _minProjectileLaunchForce;

        private Projectile _projectileInstance;
        private Vector3 _directionToLaunch;

        private void Awake()
        {
            _projectileInstance = Instantiate(_projectilePrefab, _spawnPosition.position, Quaternion.identity);
            _projectileInstance.Landed += Launch;
        }

        private void Start() => GhostLaunch();

        private void GhostLaunch()
        {
            _projectileInstance.transform.position = _spawnPosition.position;
            SelectDirectionToLaunch();
            _projectileInstance.GhostLaunch(_directionToLaunch);
        }

        private void SelectDirectionToLaunch()
        {
            _directionToLaunch = new Vector3(
                Random.Range(_minProjectileLaunchForce.x, _maxProjectileLaunchForce.x),
                Random.Range(_minProjectileLaunchForce.y, _maxProjectileLaunchForce.y),
                Random.Range(_minProjectileLaunchForce.z, _maxProjectileLaunchForce.z));
        }

        private void Launch()
        {
            _projectileInstance.Landed -= Launch;
            _projectileInstance.Landed += GameOver;

            _projectileInstance.transform.position = _spawnPosition.position;
            _projectileInstance.VisibleLaunch(_directionToLaunch);
        }

        private void GameOver()
        {
            Debug.Log("Game Over");
            _projectileInstance.Deactivate();
        }
    }
}