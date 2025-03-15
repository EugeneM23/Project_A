using UnityEngine;
using Zenject;

namespace Game.Code.Infrastructure.Systems
{
    public class GameExitController : ITickable
    {
        private readonly ApplycationFinisher _applycationFinisher;

        public GameExitController(ApplycationFinisher applycationFinisher)
        {
            _applycationFinisher = applycationFinisher;
        }

        public void Tick()
        {
            if (Input.GetKey(KeyCode.Escape)) 
                _applycationFinisher.ExitApp();
        }
    }
}