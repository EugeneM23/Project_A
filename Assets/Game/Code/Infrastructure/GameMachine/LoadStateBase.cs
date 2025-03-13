using Game.Code.GameLogick;
using Game.Code.Infrastructure.GameFactory;
using UnityEngine;

namespace Game.Code.Infrastructure.GameMachine
{
    public abstract class LoadStateBase : IPayLoadState<string>
    {
        protected readonly SceneLoader _sceneLoader;
        protected readonly SoundManager _soundManager;

        protected LoadStateBase(SceneLoader sceneLoader, SoundManager soundManager)
        {
            _soundManager = soundManager;
            _sceneLoader = sceneLoader;
        }

        public void Enter(string scene)
        {
            _soundManager.CleanUp();
            _sceneLoader.LoadLevel(scene, OnLoaded);
        }

        protected virtual void OnLoaded()
        {
            PrefabSpawner unitFactory = Object.FindAnyObjectByType<PrefabSpawner>();

            if (unitFactory != null)
            {
                Transform player = SpawnPlayer(unitFactory);

                SetCameraTarget(player);

                unitFactory.SpawnHUD();
                unitFactory.SpawnEnemys();
            }
        }

        protected abstract Transform SpawnPlayer(PrefabSpawner unitFactory);

        protected static void SetCameraTarget(Transform player)
        {
            Camera.main.GetComponent<CameraFolow>().SetTarget(player.transform);
        }

        public void Exit()
        {
        }
    }
}