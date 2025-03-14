using System;
using Unity.VisualScripting;

namespace Game.Code.GameLogick.Player
{
    public class PlayerDeathObserver : IInitializable, IDisposable
    {
        private readonly IPlayer _player;
        private readonly GameManager _gameManager;

        public PlayerDeathObserver(IPlayer player, GameManager gameManager)
        {
            _player = player;
            _gameManager = gameManager;
        }

        public void Initialize()
        {
            _player.OnDeath += OnDeath;
        }

        private void OnDeath()
        {
            _gameManager.FinishGame();
        }

        public void Dispose()
        {
        }
    }
}