using UnityEngine;
using Zenject;

namespace Game.Code.Infrastructure.Main
{
    public class GameController : ITickable
    {
        private readonly GameManager _gameManager;

        public GameController(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Q)) _gameManager.StartGame();
            if (Input.GetKeyDown(KeyCode.E)) _gameManager.PausedtGame();
            if (Input.GetKeyDown(KeyCode.R)) _gameManager.ResumeGame();
            if (Input.GetKeyDown(KeyCode.T)) _gameManager.FinishGame();
        }
    }
}