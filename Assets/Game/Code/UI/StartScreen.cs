using Game.Code.Infrastructure.Main;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Code.UI
{
    public class StartScreen : MonoBehaviour, IInitializable, IGameStartListener
    {
        [SerializeField] private Button _startButton;

        private GameStateManager _gameStateManager;

        [Inject]
        private void Construct(GameStateManager gameStateManager)
        {
            _gameStateManager = gameStateManager;
        }

        public void Initialize() => Show();

        public void OnStartGame() => Hide();

        private void Hide() => gameObject.SetActive(false);

        private void Show()
        {
            gameObject.SetActive(true);
            _startButton.onClick.AddListener(_gameStateManager.StartGame);
        }
    }
}