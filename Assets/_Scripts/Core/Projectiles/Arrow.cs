using UnityEngine;

namespace Core.Projectiles
{
    public class Arrow : Projectile
    {
        
        [SerializeField] private GameObject _landPointPrefab;
        private GameObject _landPointInstance;

        private void Awake()
        {
            _landPointInstance = Instantiate(_landPointPrefab, transform.position, Quaternion.identity);
            _landPointPrefab.SetActive(false);
        }

        public override void Launch(Vector3 direction) => Rigidbody.AddForce(direction, ForceMode.Impulse);

        public override void Deactivate()
        {
            _landPointInstance.SetActive(false);
            base.Deactivate();
        }

        private void OnCollisionEnter(Collision collision)
        {
            Rigidbody.velocity = Vector3.zero;

            if (!_landPointInstance.gameObject.activeSelf)
            {
                _landPointInstance.SetActive(true);
                _landPointInstance.transform.position = transform.position;
            }
            
             Landed?.Invoke();
        }
    }
}