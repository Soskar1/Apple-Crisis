using Cinemachine;
using Core.UI;
using UnityEngine;

namespace Core.Targets
{
    public class SceneBootstrap : MonoBehaviour
    {
        [SerializeField] private GameObject _target;
        [SerializeField] private Transform _spawnPoint;

        private void Awake()
        {
            GameObject targetInstance = Instantiate(_target, _spawnPoint.position, Quaternion.identity);

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