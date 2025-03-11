using UnityEngine;
using Zenject;

namespace Code.Infrastructure.GameMachine
{
    public class LoadLevelState : IPayLoadState<string>
    {
        DiContainer container;
        private readonly LazyInject<GameStateMachine> _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private UnitSpawner _unitSpawner;

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
            //_unitSpawner = container.Resolve<UnitSpawner>();
            var unitFactory = Object.FindAnyObjectByType<UnitSpawner>();

            if (unitFactory != null)
                unitFactory.SpawnPlayer();

            Debug.Log("Loading level");
        }

        public void Exit()
        {
        }
    }
}