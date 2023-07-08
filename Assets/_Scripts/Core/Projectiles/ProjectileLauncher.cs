using UnityEngine;

namespace Core.Projectiles
{
    public class ProjectileLauncher : MonoBehaviour
    {
        [SerializeField] private Projectile _projectilePrefab;
        [SerializeField] private Transform _spawnPosition;
        [SerializeField] private float _spawnRate;

        [SerializeField] private Vector3 _maxProjectileLaunchForce;
        [SerializeField] private Vector3 _minProjectileLaunchForce;
        private float _timer;

        private Projectile _projectileInstance;
        private Vector3 _directionToLaunch;

        private void Awake()
        {
            _projectileInstance = Instantiate(_projectilePrefab, _spawnPosition.position, Quaternion.identity);

            _projectileInstance.Landed += GhostLaunch;

            _timer = _spawnRate;
        }

        private void Start() => GhostLaunch();

        private void OnDisable() => _projectileInstance.Landed -= GhostLaunch;

        private void Update()
        {
            if (!_projectileInstance.IsGhost)
                return;

            if (!_projectileInstance.gameObject.activeSelf)
                return;

            if (_timer <= 0)
            {
                _projectileInstance.transform.position = _spawnPosition.position;
                _projectileInstance.VisibleLaunch(_directionToLaunch);

                _timer = _spawnRate;
            }
            else
            {
                _timer -= Time.deltaTime;
            }
        }

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
    }
}