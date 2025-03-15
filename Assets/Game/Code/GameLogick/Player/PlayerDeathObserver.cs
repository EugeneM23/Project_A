using System;
using Game.Code.Infrastructure.Main;
using Game.Code.Infrastructure.Systems;
using Unity.VisualScripting;

namespace Game.Code.GameLogick.Player
{
    public class PlayerDeathObserver : IInitializable, IDisposable
    {
        private readonly IPlayer _player;
        private readonly GameStateManager _gameStateManager;

        public PlayerDeathObserver(IPlayer player, GameStateManager gameStateManager)
        {
            _player = player;
            _gameStateManager = gameStateManager;
        }

        public void Initialize() => _player.OnDeath += OnDeath;
        public void Dispose() => _player.OnDeath -= OnDeath;

        
        private void OnDeath() => _gameStateManager.FinishGame();
    }
}