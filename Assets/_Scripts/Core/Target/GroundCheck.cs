using UnityEngine;

namespace Core.Targets
{
    public class GroundCheck : MonoBehaviour
    {
        [SerializeField] private Transform _groundCheckPoint;
        [SerializeField] private float _rayDistance;
        [SerializeField] private LayerMask _groundLayer;

        public bool CheckForGround()
        {
            Ray ray = new Ray(transform.position, Vector3.down);
            if (Physics.Raycast(ray, _rayDistance, _groundLayer))
                return true;

            return false;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - _rayDistance, transform.position.z));
        }
    }
}