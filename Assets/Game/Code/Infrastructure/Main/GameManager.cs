using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Code.Infrastructure.Main
{
    public class GameManager
    {
        public event Action OnGameStart;
        public event Action OnGameFinished;
        public event Action OnGamePause;
        public event Action OnGameResume;

        private List<IGameStateListener> _listeners = new();
        public GameState CurrentState { get; private set; }

        public void AddListener(IGameStateListener listener) => _listeners.Add(listener);

        public void RemoveListener(IGameStateListener listener) => _listeners.Remove(listener);

        public void StartGame()
        {
            if (CurrentState != GameState.OFF)
                return;
            
            foreach (var it in _listeners)
                if (it is IGameStartListener listener)
                    listener.OnStartGame();

            CurrentState = GameState.PLAY;

            OnGameStart?.Invoke();
            Debug.Log("Game started");
        }

        public void PausedtGame()
        {
            if (CurrentState != GameState.PLAY)
                return;
            
            foreach (var it in _listeners)
                if (it is IGamePauseListener listener)
                    listener.OnPauseGame();

            CurrentState = GameState.PAUSe;

            OnGamePause?.Invoke();
            Debug.Log("Paused");
        }

        public void ResumeGame()
        {
            if (CurrentState != GameState.PAUSe)
                return;

            foreach (var it in _listeners)
                if (it is IGameResumListener listener)
                    listener.OnResumeGame();
            
            CurrentState = GameState.PLAY;

            OnGameResume?.Invoke();
            Debug.Log("Game resumed");
        }

        public void FinishGame()
        {
            if (CurrentState is not (GameState.PLAY or GameState.PAUSe)) return;

            foreach (var it in _listeners)
                if (it is IGameFinishListener listener)
                    listener.OnFinishGame();
            
            CurrentState = GameState.FINISH;

            OnGameFinished?.Invoke();
            Debug.Log("Game finished");
        }
    }

    public enum GameState
    {
        OFF = 0,
        PLAY = 1,
        PAUSe = 2,
        FINISH = 3,
    }
}