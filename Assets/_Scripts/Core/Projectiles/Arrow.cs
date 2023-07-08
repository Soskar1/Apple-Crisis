using UnityEngine;

namespace Core.Projectiles
{
    public class Arrow : Projectile
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private GameObject _landPointPrefab;
        private GameObject _landPointInstance;

        private void Awake()
        {
            _landPointInstance = Instantiate(_landPointPrefab, transform.position, Quaternion.identity);
            _landPointPrefab.SetActive(false);
        }

        public override void Launch(Vector3 direction) => _rigidbody.AddForce(direction, ForceMode.Impulse);

        public override void Deactivate()
        {
            _landPointInstance.SetActive(false);
            base.Deactivate();
        }

        private void OnCollisionEnter(Collision collision)
        {
            _rigidbody.velocity = Vector3.zero;

            _landPointInstance.SetActive(IsGhost);
            _landPointInstance.transform.position = transform.position;
            
            if (!IsGhost)
                Landed?.Invoke();
        }
    }
}