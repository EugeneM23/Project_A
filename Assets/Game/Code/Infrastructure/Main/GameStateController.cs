using Game.Code.Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace Game.Code.Infrastructure.Main
{
    public class GameStateController : ITickable
    {
        private readonly GameStateManager _gameStateManager;
        private readonly PlayerProgressService _playerProgressService;

        public GameStateController(GameStateManager gameStateManager)
        {
            _gameStateManager = gameStateManager;
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Q)) _gameStateManager.StartGame();
            if (Input.GetKeyDown(KeyCode.E)) _gameStateManager.PausedtGame();
            if (Input.GetKeyDown(KeyCode.R)) _gameStateManager.ResumeGame();
            if (Input.GetKeyDown(KeyCode.T)) _gameStateManager.FinishGame();
        }
    }
}