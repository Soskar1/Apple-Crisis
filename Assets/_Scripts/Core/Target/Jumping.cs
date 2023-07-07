using UnityEngine;

namespace Core.Targets
{
    public class Jumping : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _power;

        public void Jump() => _rigidbody.AddForce(Vector3.up * _power, ForceMode.Impulse);
    }
}