using Core.UI;
using UnityEngine;
using Zenject;

namespace Core.Targets
{
    public class SceneBootstrap : MonoBehaviour
    {
        [SerializeField] private Target _target;
        [SerializeField] private Transform _spawnPoint;
        private Input _input;

        [Inject]
        public void Construct(Input input) => _input = input;

        private void Awake()
        {
            Target targetInstance = Instantiate(_target, _spawnPoint.position, Quaternion.identity);
            targetInstance.Initialize(_input);
            _input.Enable();

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