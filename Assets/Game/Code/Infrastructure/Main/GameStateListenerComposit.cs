using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Code.Infrastructure.Main
{
    public class GameStateListenerComposit : MonoBehaviour, IGameStartListener, IGamePauseListener, IGameResumListener, IGameFinishListener
    {
        [Inject] private readonly GameManager _gameManager;
        
        [InjectLocal]
        private List<IGameStateListener> _listeners = new();

        private void Start() => _gameManager.AddListener(this);

        private void OnDestroy() => _gameManager.RemoveListener(this); 

        public void OnStartGame()
        {
            foreach (var it in _listeners)
                if (it is IGameStartListener listener)
                    listener.OnStartGame();
        }

        public void OnPauseGame()
        {
            foreach (var it in _listeners)
                if (it is IGamePauseListener listener)
                    listener.OnPauseGame();
        }

        public void OnResumeGame()
        {
            foreach (var it in _listeners)
                if (it is IGameResumListener listener)
                    listener.OnResumeGame();
        }

        public void OnFinishGame()
        {
            foreach (var it in _listeners)
                if (it is IGameFinishListener listener)
                    listener.OnFinishGame();
        }
    }
}