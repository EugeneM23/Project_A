using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Game.Code.Infrastructure.GameMachine
{
    public class SceneLoader
    {
        private readonly LazyInject<ICoroutineRunner> _couroutineRunner;

        public SceneLoader(LazyInject<ICoroutineRunner> couroutineRunner)
        {
            _couroutineRunner = couroutineRunner;
        }

        public void LoadLevel(string levelName, Action onLoaded = null)
        {
            _couroutineRunner.Value.StartRoutine(Load(levelName, onLoaded));
        }

        private IEnumerator Load(string levelName, Action onLoaded)
        {
            if (levelName == SceneManager.GetActiveScene().name)
            {
                onLoaded?.Invoke();
                yield break;
            }

            AsyncOperation operation = SceneManager.LoadSceneAsync(levelName);

            while (operation.isDone == false)
            {
                yield return null;
            }

            yield return null;

            onLoaded?.Invoke();

            yield return null;
        }
    }
}