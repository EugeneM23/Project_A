using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Code.Infrastructure.SceneLoadComposite
{
    public interface ILoadingStep
    {
        Task Execute();
    }

    public class LoadLoadingScreenStep : ILoadingStep
    {
        private string loadingSceneName;

        public LoadLoadingScreenStep(string sceneName)
        {
            loadingSceneName = sceneName;
        }

        public async Task Execute()
        {
            AsyncOperation loadOp = SceneManager.LoadSceneAsync(loadingSceneName);
            while (!loadOp.isDone)
            {
                await Task.Yield();
            }
        }
    }

    public class LoadLevelStep : ILoadingStep
    {
        private string levelSceneName;
        private AsyncOperation loadOperation;

        public LoadLevelStep(string sceneName)
        {
            levelSceneName = sceneName;
        }

        public async Task Execute()
        {
            loadOperation = SceneManager.LoadSceneAsync(levelSceneName, LoadSceneMode.Additive);
            loadOperation.allowSceneActivation = false;

            // Ждём загрузки до 90%
            while (loadOperation.progress < 0.9f)
            {
                await Task.Yield();
            }
        }

        public async Task WaitUntilSceneLoaded()
        {
            // Разрешаем активацию сцены
            loadOperation.allowSceneActivation = true;

            // Ждём, пока сцена полностью загрузится
            while (!loadOperation.isDone)
            {
                await Task.Yield();
            }
        }
    }

    public class InitializeGameObjectsStep : ILoadingStep
    {
        public async Task Execute()
        {
            // Инициализация игрока
            GameObject playerPrefab = Resources.Load<GameObject>("EnemyRed");
            GameObject.Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);

            // Создание монстров
            for (int i = 0; i < 5; i++)
            {
                GameObject enemyPrefab = Resources.Load<GameObject>("EnemyGreen");
                GameObject.Instantiate(enemyPrefab, new Vector3(i * 2, 0, 0), Quaternion.identity);
            }

            await Task.Yield();
        }
    }
    
    public class SwitchToLevelStep : ILoadingStep
    {
        private string levelSceneName;

        public SwitchToLevelStep(string sceneName)
        {
            levelSceneName = sceneName;
        }

        public async Task Execute()
        {
            // Ждём, пока сцена появится в списке загруженных сцен
            while (!SceneManager.GetSceneByName(levelSceneName).isLoaded)
            {
                await Task.Yield();
            }

            // Переключаемся на новую сцену
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(levelSceneName));
        }
    }
    
    public class LevelLoader
    {
        private List<ILoadingStep> steps = new List<ILoadingStep>();

        public void AddStep(ILoadingStep step)
        {
            steps.Add(step);
        }

        public async Task LoadLevel()
        {
            foreach (var step in steps)
            {
                await step.Execute();
            }
        }
    }
}