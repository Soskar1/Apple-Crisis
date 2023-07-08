using Cinemachine;
using Core.UI;
using UnityEngine;

namespace Core.Targets
{
    public class SceneBootstrap : MonoBehaviour
    {
        [SerializeField] private GameObject _target;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private CinemachineFreeLook _camera;
        [SerializeField] private HintArrow _hintArrow;

        private void Awake()
        {
            GameObject targetInstance = Instantiate(_target, _spawnPoint.position, Quaternion.identity);
            _camera.Follow = targetInstance.transform;
            _camera.LookAt = targetInstance.transform;
            _hintArrow.Initialize(targetInstance.transform);

            HideCursor();

            //Target & Ghost
            Physics.IgnoreLayerCollision(6, 7);

            //Ghost & Projectile
            Physics.IgnoreLayerCollision(7, 8);
        }

        private void HideCursor()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}