using Game.Code.Infrastructure.Main;
using UnityEngine;
using Zenject;

namespace Game.Code.UI
{
    public class HUD : MonoBehaviour, IInitializable, IGameStartListener, IGamePauseListener, IGameResumListener
    {
        [Inject] private GameStateManager _gameStateManager;

        public void Initialize()
        {
            _gameStateManager.AddListener(this);
            Hide();
        }

        public void OnStartGame() => Show();

        public void OnResumeGame() => Show();

        public void OnPauseGame() => Hide();

        private void Show()
        {
            Debug.Log("Show");
            gameObject.SetActive(true);
        }

        private void Hide()
        {
            Debug.Log("Hide");
            gameObject.SetActive(false);
        }

        public class Factory : PlaceholderFactory<Object, HUD>
        {
        }
    }
}