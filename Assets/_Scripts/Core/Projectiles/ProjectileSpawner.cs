using UnityEngine;

namespace Core.Projectiles
{
    public class ProjectileSpawner : MonoBehaviour
    {
        [SerializeField] private Projectile _projectilePrefab;
        [SerializeField] private Transform _spawnPosition;
        [SerializeField] private float _spawnRate;

        [SerializeField] private Vector3 _maxProjectileLaunchForce;
        [SerializeField] private Vector3 _minProjectileLaunchForce;
        private float _timer;

        private Vector3 _directionToLaunch;

        private void Awake() => _timer = _spawnRate;

        private void Update()
        {
            if (_timer <= 0)
            {
                SelectDirctionToLaunch();
                Spawn();
                _timer = _spawnRate;
            }
            else
            {
                _timer -= Time.deltaTime;
            }
        }

        private void SelectDirctionToLaunch()
        {
            _directionToLaunch = new Vector3(
                Random.Range(_minProjectileLaunchForce.x, _maxProjectileLaunchForce.x),
                Random.Range(_minProjectileLaunchForce.y, _maxProjectileLaunchForce.y),
                Random.Range(_minProjectileLaunchForce.z, _maxProjectileLaunchForce.z));

            Debug.Log(_directionToLaunch);
        }

        private void Spawn()
        {
            Projectile projectileInstance = Instantiate(_projectilePrefab, _spawnPosition.position, Quaternion.identity);
            projectileInstance.Launch(_directionToLaunch);
        }
    }
}