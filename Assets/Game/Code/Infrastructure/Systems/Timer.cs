using Game.Code.Infrastructure.Main;
using UnityEngine;

namespace Game.Code.Infrastructure.Systems
{
    public class Timer : IGameTickable
    {
        private GameStateManager gameStateManager;

        public Timer(GameStateManager gameStateManager)
        {
            this.gameStateManager = gameStateManager;
        }

        public void Tick(float deltaTime)
        {
            Debug.Log(gameStateManager.CurrentState);
        }
    }
}