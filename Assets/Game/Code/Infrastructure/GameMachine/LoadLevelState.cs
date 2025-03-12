using Game.Code.Infrastructure.GameFactory;
using UnityEngine;

namespace Game.Code.Infrastructure.GameMachine
{
    public class LoadLevelState : LoadStateBase
    {
        public LoadLevelState(SceneLoader sceneLoader) : base(sceneLoader)
        {
        }

        protected override Transform SpawnPlayer(PrefabSpawner unitFactory)
        {
            Vector3 playerSpawnPoint = Object.FindAnyObjectByType<PlayerSpawnPoint>().transform.position;
            return unitFactory.SpawnPlayer(at: playerSpawnPoint);
        }
    }
}