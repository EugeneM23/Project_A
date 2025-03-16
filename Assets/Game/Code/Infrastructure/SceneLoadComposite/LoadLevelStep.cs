using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Code.Infrastructure.SceneLoadComposite
{
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

            while (loadOperation.progress < 0.9f)
            {
                await Task.Yield();
            }
        }

        public async Task WaitUntilSceneLoaded()
        {
            loadOperation.allowSceneActivation = true;

            while (!loadOperation.isDone)
            {
                await Task.Yield();
            }
        }
    }
}