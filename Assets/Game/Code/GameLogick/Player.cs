using Game.Code.Infrastructure.GameMachine;
using Game.Code.Infrastructure.Services;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        private PlayerProgressService _playerProgressService;
        private int _currentHealth = 100;
        private string _currentWeapon = "Pistol";
        private GameStateMachine _stateMachine;

        [Inject]
        private void Construct(InputService inputService, PlayerProgressService playerProgressService,
            GameStateMachine stateMachine)
        {
            _playerProgressService = playerProgressService;
            _inputService = inputService;
            _stateMachine = stateMachine;
        }

        private void Start() => _camera = Camera.main;

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
        }

        private void LoadProgress()
        {
            PlayerData playerData = _playerProgressService.Load();

            if (SceneManager.GetActiveScene().name != playerData.Level)
                _stateMachine.SetState<LoadProgressState, string>(playerData.Level);

            Warp(playerData);
            PrintDebug(playerData);
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