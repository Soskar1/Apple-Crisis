using UnityEngine;

namespace Core.UI
{
    public class HintArrow : MonoBehaviour
    {
        [SerializeField] private GameObject _visual;
        [SerializeField] private float _offset;
        private Transform _player;
        private Vector3 _pointTo = Vector3.zero;
        private Camera _camera;

        private void Awake() => _camera = Camera.main;

        private void Update()
        {
            if (_pointTo == Vector3.zero)
                return;

            Vector2 playerPosition = new Vector2(_player.position.x, _player.position.z);
            Vector2 pointToPosition = new Vector2(_pointTo.x, _pointTo.z);

            Vector2 direction = (pointToPosition - playerPosition).normalized;
            float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + _camera.transform.eulerAngles.y;
            _visual.transform.localEulerAngles = new Vector3(0, 0, rotZ + _offset);
        }

        public void Initialize(Transform player) => _player = player;

        public void StartPointing(Vector3 pointTo)
        {
            _pointTo = pointTo;
            _visual.SetActive(true);
        }
    }
}