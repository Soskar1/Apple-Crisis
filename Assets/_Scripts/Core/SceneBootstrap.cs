using Cinemachine;
using UnityEngine;

namespace Core.Targets
{
    public class SceneBootstrap : MonoBehaviour
    {
        [SerializeField] private GameObject _target;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private CinemachineFreeLook _camera;

        private void Awake()
        {
            GameObject targetInstance = Instantiate(_target, _spawnPoint.position, Quaternion.identity);
            _camera.Follow = targetInstance.transform;
            _camera.LookAt = targetInstance.transform;

            HideCursor();
        }

        private void HideCursor()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}