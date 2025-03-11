using UnityEngine;

namespace Game.Code.GameLogick
{
    public class CameraFolow : MonoBehaviour
    {
        [SerializeField] private Vector3 _offset;
        private Transform _target;

        private void LateUpdate()
        {
            if (_target != null)
            {
                MoveToTarget(_target);
            }
        }

        private void MoveToTarget(Transform target) => transform.position = _offset + target.position;

        public void SetTarget(Transform target) => _target = target;
    }
}