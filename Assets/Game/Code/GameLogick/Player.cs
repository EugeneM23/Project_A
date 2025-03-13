using FMOD.Studio;
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

        private EventInstance _playerFootStep;
        private SoundManager _soundManager;
        private InputService _inputService;
        private Camera _camera;

        [Inject]
        private void Construct(InputService inputService, PlayerProgressService playerProgressService,
            SoundManager soundManager)
        {
            _inputService = inputService;
            _soundManager = soundManager;
        }

        private void Start()
        {
            _playerFootStep = _soundManager.CreateInstance(FMODEvents.FootStepsEvent);
            _camera = Camera.main;
        }

        private void UpdateSound()
        {
            if (_inputService.Axis.sqrMagnitude > 0 && _controller.isGrounded)
            {
                PLAYBACK_STATE playbackState;
                _playerFootStep.getPlaybackState(out playbackState);
                
                if (playbackState.Equals(PLAYBACK_STATE.STOPPED)) 
                    _playerFootStep.start();
            }
            else
            {
                _playerFootStep.stop(STOP_MODE.IMMEDIATE);
            }
        }

        private void Update()
        {
            TestInputs();
            Movement();
            UpdateSound();
        }

        private void Movement()
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

        private static void TestInputs()
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
            }
        }

        private void RotateTowards(Vector3 movementVector)
        {
            if (movementVector == Vector3.zero) return;
            var targetRotation = Quaternion.LookRotation(movementVector);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
        }
    }
}