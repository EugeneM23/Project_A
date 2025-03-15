using Game.Code.GameLogick.Player;
using Game.Code.Infrastructure.Services;
using Game.Code.Infrastructure.Systems;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Game.Code.Infrastructure.Main
{
    public class GameSvaLoadController : IInitializable, IGameTickable
    {
        private readonly PlayerProgressService _playerProgressService;
        private readonly PlayerBase _player;

        public GameSvaLoadController(PlayerProgressService playerProgressService, PlayerBase player)
        {
            _playerProgressService = playerProgressService;
            _player = player;
        }

        public void Tick(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.C)) Save();
            if (Input.GetKeyDown(KeyCode.V)) Load();
            if (Input.GetKeyDown(KeyCode.B)) _playerProgressService.Delete();
        }

        private void Load()
        {
            PlayerData data = _playerProgressService.Load();
            if (data.Level != SceneManager.GetActiveScene().name)
            {
                SceneManager.LoadScene(data.Level); 
            }
            
            _player.LoadData(data);
        }

        private void Save()
        {
            PlayerData data = _player.GetData();
            _playerProgressService.Save(data);
        }

        public void Initialize()
        {
        }
    }
}