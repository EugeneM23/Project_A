using Game.Code.GameLogick;
using Game.Code.Infrastructure.GameFactory;
using UnityEngine;

namespace Game.Code.Infrastructure.GameMachine
{
    /*public class LoadProgressState : IPayLoadState<string>
    {
        private readonly SceneLoader _sceneLoader;

        public LoadProgressState(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void Enter(string scene)
        {
            _sceneLoader.LoadLevel(scene, OnLoaded);
        }

        private void OnLoaded()
        {
            PrefabSpawner unitFactory = Object.FindAnyObjectByType<PrefabSpawner>();
            Vector3 playerSpawnPoint = Object.FindAnyObjectByType<PlayerSpawnPoint>().transform.position;

            if (unitFactory != null)
            {
                Transform player = unitFactory.SpawnPlayer(at: playerSpawnPoint);

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
    }*/
}