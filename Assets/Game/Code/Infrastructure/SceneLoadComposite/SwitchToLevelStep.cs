using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Game.Code.Infrastructure.SceneLoadComposite
{
    public class SwitchToLevelStep : ILoadingStep
    {
        private string levelSceneName;

        public SwitchToLevelStep(string sceneName)
        {
            levelSceneName = sceneName;
        }

        public async Task Execute()
        {
            while (!SceneManager.GetSceneByName(levelSceneName).isLoaded)
            {
                await Task.Yield();
            }

            SceneManager.SetActiveScene(SceneManager.GetSceneByName(levelSceneName));
        }
    }
}