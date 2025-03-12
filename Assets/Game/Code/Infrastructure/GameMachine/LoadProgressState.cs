using Game.Code.GameLogick;
using Game.Code.Infrastructure.GameFactory;
using Game.Code.Infrastructure.Services;
using UnityEngine;

namespace Game.Code.Infrastructure.GameMachine
{
    public class LoadProgressState : IPayLoadState<string>
    {
        private readonly SceneLoader _sceneLoader;
        private readonly PlayerProgressService _playerProgressService;

        public LoadProgressState(SceneLoader sceneLoader, PlayerProgressService playerProgressService)
        {
            _sceneLoader = sceneLoader;
            _playerProgressService = playerProgressService;
        }

        public void Enter(string scene)
        {
            _sceneLoader.LoadLevel(scene, OnLoaded);
        }

        private void OnLoaded()
        {
            PrefabSpawner unitFactory = Object.FindAnyObjectByType<PrefabSpawner>();
            PlayerData playerData = _playerProgressService.Load();

            if (unitFactory != null)
            {
                Transform player = unitFactory.SpawnPlayer(at: playerData.PositionOnlevel);

                SetCameraTarget(player);

                unitFactory.SpawnHUD();
                unitFactory.SpawnEnemys();
            }
        }

        private static void SetCameraTarget(Transform player)
        {
            Camera.main.GetComponent<CameraFolow>().SetTarget(player.transform);
        }

        public void Exit()
        {
        }
    }
}