using Game.Code.Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace Game.Code.GameLogick
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private CharacterController _controller;
        [SerializeField] private float _rotationSpeed = 5f;

        private Camera _camera;
        private InputService _inputService;

        [Inject]
        private void Construct(InputService inputService) => _inputService = inputService;

        private void Start() => _camera = Camera.main;

        private void Update()
        {
            var movementVector = Vector3.zero;
            if (_inputService.Axis.sqrMagnitude > 0)
            {
                movementVector = _camera.transform.TransformDirection(_inputService.Axis);
                movementVector.y = 0;
                movementVector.Normalize();
            }

            RotateTowards(movementVector);
            movementVector += Physics.gravity;

            _controller.Move(_speed * movementVector * Time.deltaTime);
        }

        private void RotateTowards(Vector3 movementVector)
        {
            if (movementVector == Vector3.zero) return;

            var targetRotation = Quaternion.LookRotation(movementVector);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
        }
        
        public class Factory : PlaceholderFactory<UnityEngine.Object, Player>
        {
        }
    }
}