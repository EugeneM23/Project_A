using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Code.Infrastructure.SceneLoadComposite
{
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
}