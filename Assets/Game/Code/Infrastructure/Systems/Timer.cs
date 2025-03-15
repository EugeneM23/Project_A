using Game.Code.Infrastructure.Main;
using UnityEngine;

namespace Game.Code.Infrastructure.Systems
{
    public class Timer : IGameTickable
    {
        public void Tick(float deltaTime)
        {
            Debug.Log("Timer");
        }
    }
}