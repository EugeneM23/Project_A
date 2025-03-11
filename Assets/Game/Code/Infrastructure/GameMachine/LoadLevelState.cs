using Game.Code.GameLogick;
using Game.Code.Infrastructure.GameFactory;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Game.Code.Infrastructure.GameMachine
{
    public class LoadLevelState : IPayLoadState<string>
    {
        DiContainer container;
        private readonly LazyInject<GameStateMachine> _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private PrefabSpawner _prefabSpawner;

        public LoadLevelState(LazyInject<GameStateMachine> stateMachine,
            SceneLoader sceneLoader, DiContainer container)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            this.container = container;
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

            Debug.Log("Loading level");
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