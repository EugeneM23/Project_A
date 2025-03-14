using System;
using Game.Code.Infrastructure.Systems;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Code.UI
{
    public class StartGameButton : IInitializable, IDisposable
    {
        private readonly Button _button;
        private readonly GameLauncher _launcher;

        public StartGameButton(Button button, GameLauncher launcher)
        {
            _button = button;
            _launcher = launcher;
        }

        public void Initialize() => _button.onClick.AddListener(OnButtonClicked);

        public void Dispose() => _button.onClick.RemoveListener(OnButtonClicked);
        private void OnButtonClicked() => _launcher.StartGame();
    }
}