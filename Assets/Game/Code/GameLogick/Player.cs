using System;
using FMOD.Studio;
using FMODUnity;
using Game.Code.Infrastructure.GameMachine;
using Game.Code.Infrastructure.Services;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using STOP_MODE = FMOD.Studio.STOP_MODE;

namespace Game.Code.GameLogick
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private CharacterController _controller;
        [SerializeField] private float _rotationSpeed = 5f;

        private Camera _camera;
        private InputService _inputService;
        private PlayerProgressService _playerProgressService;
        private int _currentHealth = 100;
        private string _currentWeapon = "Pistol";
        private GameStateMachine _stateMachine;

        private EventInstance _playerFootStep;
        private SoundManager _soundManager;

        [Inject]
        private void Construct(InputService inputService, PlayerProgressService playerProgressService,
            GameStateMachine stateMachine, SoundManager soundManager)
        {
            _playerProgressService = playerProgressService;
            _inputService = inputService;
            _stateMachine = stateMachine;
            _soundManager = soundManager;
        }

        private void Start()
        {
            _playerFootStep =_soundManager.CreateInstance(FMODEvents.FootStepsEvent);
            _camera = Camera.main;
        }

        private void UpdateSound()
        {
            if (_inputService.Axis.sqrMagnitude > 0 && _controller.isGrounded)
            {
                Debug.Log("Step");
                PLAYBACK_STATE playbackState;
                _playerFootStep.getPlaybackState(out playbackState);
                if (playbackState.Equals(PLAYBACK_STATE.STOPPED))
                {
                    _playerFootStep.start();
                }
            }
            else
            {
                _playerFootStep.stop(STOP_MODE.IMMEDIATE);
            }
        }

        private void Update()
        {
            TestSaveLoad();

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
            UpdateSound();
        }

        private void TestSaveLoad()
        {
            if (Input.GetKeyDown(KeyCode.V)) SaveProgress();

            if (Input.GetKeyDown(KeyCode.C)) LoadProgress();

            if (Input.GetKeyDown(KeyCode.B))
            {
                _playerProgressService.Delete();
            }
        }

        private void RotateTowards(Vector3 movementVector)
        {
            if (movementVector == Vector3.zero) return;

            var targetRotation = Quaternion.LookRotation(movementVector);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
        }

        private void SaveProgress()
        {
            _playerProgressService.Save(CreatePlayerData());

            _soundManager.PlayeOneShot("event:/LoadGame");
        }

        private void LoadProgress()
        {
            PlayerData playerData = _playerProgressService.Load();

            if (SceneManager.GetActiveScene().name != playerData.Level)
                _stateMachine.SetState<LoadProgressState, string>(playerData.Level);

            Warp(playerData);
            PrintDebug(playerData);

            _soundManager.PlayeOneShot("event:/SavedGame");
        }

        private void Warp(PlayerData playerData)
        {
            _controller.enabled = false;
            gameObject.transform.position = playerData.PositionOnlevel;
            _controller.enabled = true;
        }

        private PlayerData CreatePlayerData()
        {
            PlayerData playerData = new PlayerData();

            playerData.Health = _currentHealth;
            playerData.Level = SceneManager.GetActiveScene().name;
            playerData.CurrentWeapon = _currentWeapon;
            playerData.PositionOnlevel = transform.position;

            return playerData;
        }

        private void PrintDebug(PlayerData playerData)
        {
            Debug.Log($"Player data Health: {playerData.Health}");
            Debug.Log($"Player data CurrentWeapon: {playerData.CurrentWeapon}");
            Debug.Log($"Player data PositionOnlevel: {playerData.PositionOnlevel}");
            Debug.Log($"Player data Level: {playerData.Level}");
        }

        public class Factory : PlaceholderFactory<UnityEngine.Object, Player>
        {
        }
    }
}