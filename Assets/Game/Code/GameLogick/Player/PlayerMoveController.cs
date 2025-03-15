using Game.Code.Infrastructure.Main;
using Game.Code.Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace Game.Code.GameLogick.Player
{
    public class PlayerMoveController : IGameTickable, IInitializable
    {
        private readonly Transform _playerTransform;
        private readonly InputService _inputService;
        private readonly CharacterController _characterController;

        private Camera _camera;
        private float _speed;
        private float _rotationSpeed;

        public PlayerMoveController(IPlayer player, InputService inputService, float speed, float rotationSpeed)
        {
            _inputService = inputService;
            _speed = speed;
            _rotationSpeed = rotationSpeed;

            _characterController = (player as PlayerBase).gameObject.GetComponent<CharacterController>();
            _playerTransform = (player as PlayerBase).gameObject.transform;
        }

        public void Initialize() => _camera = UnityEngine.Camera.main;

        public void Tick(float deltaTime)
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

            _characterController.Move(_speed * movementVector * Time.deltaTime);
        }

        private void RotateTowards(Vector3 movementVector)
        {
            if (movementVector == Vector3.zero) return;
            var targetRotation = Quaternion.LookRotation(movementVector);
            _playerTransform.rotation =
                Quaternion.Slerp(_playerTransform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
        }
    }
}