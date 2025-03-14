using System;
using Game.Code.Infrastructure.Systems;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Code.UI
{
    public class FinishGameButton : IInitializable, IDisposable
    {
        private readonly Button _button;
        private readonly ApplycationFinisher _finisher;

        public FinishGameButton(Button button, ApplycationFinisher finisher)
        {
            _button = button;
            _finisher = finisher;
        }

        public void Initialize()
        {
            _button.onClick.AddListener(OnButtonClicked);
        }

        public void Dispose() => _button.onClick.RemoveListener(OnButtonClicked);
        private void OnButtonClicked()
        {
            _finisher.FinishGame();
        }
    }
}