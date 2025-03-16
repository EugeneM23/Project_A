using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Code.Infrastructure.SceneLoadComposite
{
    public class LoadManager : MonoBehaviour
    {
        private async void Start()
        {
            LevelLoader loader = new LevelLoader();

            string loadingScreen = "L_Boot";
            string levelScene = "L_Base";

            LoadLevelStep levelStep = new LoadLevelStep(levelScene);

            loader.AddStep(new LoadLoadingScreenStep(loadingScreen));
            loader.AddStep(levelStep);
            loader.AddStep(new InitializeGameObjectsStep());

            await loader.LoadLevel();

            // Дожидаемся полной загрузки уровня перед переключением сцены
            await levelStep.WaitUntilSceneLoaded();

            // Переключаем сцену после полной загрузки
            await new SwitchToLevelStep(levelScene).Execute();
            
            GameObject loadingScreenCanvas = GameObject.FindWithTag("LoadingScreen");
            loadingScreenCanvas.SetActive(false);
            //SceneManager.UnloadSceneAsync(loadingScreen);
        }
    }
}