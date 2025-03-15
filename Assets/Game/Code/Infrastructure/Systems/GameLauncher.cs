using Game.Code.Infrastructure.Services;
using UnityEngine.SceneManagement;
using Zenject;

namespace Game.Code.Infrastructure.Systems
{
    public class GameLauncher : IInitializable
    {
        private readonly PlayerProgressService _playerProgressService;

        public GameLauncher(PlayerProgressService playerProgressService)
        {
            _playerProgressService = playerProgressService;
        }

        public void StartGame()
        {
            PlayerData data = _playerProgressService.Load();
            LoadLevel(data);
        }

        public void LoadLevel(PlayerData data)
        {
            SceneManager.LoadScene(data.Level);
        }

        public void Initialize()
        {
        }
    }
}