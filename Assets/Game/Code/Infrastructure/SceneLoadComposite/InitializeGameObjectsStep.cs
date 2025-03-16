using System.Threading.Tasks;
using UnityEngine;

namespace Game.Code.Infrastructure.SceneLoadComposite
{
    public class InitializeGameObjectsStep : ILoadingStep
    {
        public async Task Execute()
        {
            GameObject playerPrefab = Resources.Load<GameObject>("EnemyRed");
            GameObject.Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);

            for (int i = 0; i < 5; i++)
            {
                GameObject enemyPrefab = Resources.Load<GameObject>("EnemyGreen");
                GameObject.Instantiate(enemyPrefab, new Vector3(i * 2, 0, 0), Quaternion.identity);
            }

            await Task.Yield();
        }
    }
}