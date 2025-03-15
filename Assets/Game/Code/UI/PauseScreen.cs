using Game.Code.Infrastructure.Main;
using Game.Code.Infrastructure.Systems;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Code.UI
{
    public class PauseScreen : MonoBehaviour, IGamePauseListener, IGameResumListener, IGameFinishListener
    {
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _finishButton;
        [SerializeField] private Button _exitButton;

        private GameStateManager _gameStateManager;
        private ApplycationFinisher _applycationFinisher;

        [Inject]
        public void Construct(GameStateManager gameStateManager, ApplycationFinisher applycationFinisher)
        {
            _gameStateManager = gameStateManager;
            _applycationFinisher = applycationFinisher;
            gameObject.SetActive(false);
        }

        public void OnPauseGame() => Show();
        public void OnFinishGame() => Hide();
        public void OnResumeGame() => Hide();

        private void Show()
        {
            gameObject.SetActive(true);

            _resumeButton.onClick.AddListener(_gameStateManager.ResumeGame);
            _finishButton.onClick.AddListener(_gameStateManager.FinishGame);
            _exitButton.onClick.AddListener(_applycationFinisher.ExitApp);
        }

        private void Hide()
        {
            gameObject.SetActive(false);

            _resumeButton.onClick.RemoveListener(_gameStateManager.ResumeGame);
            _finishButton.onClick.RemoveListener(_gameStateManager.FinishGame);
            _exitButton.onClick.RemoveListener(_applycationFinisher.ExitApp);
        }
    }
}