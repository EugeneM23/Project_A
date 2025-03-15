using System.Collections.Generic;
using Game.Code.GameLogick.CameraLogick;
using UnityEngine;
using Zenject;

namespace Game.Code.Infrastructure.Main
{
    public class GameKernel : MonoKernel
    {
        [InjectLocal] private List<IGameTickable> _tickables = new();
        [InjectLocal] private List<IGameLateTickable> _lateTickables = new();
        [InjectLocal] private List<IGameFixedTickable> _fixedTickables = new();

        [Inject] private readonly GameManager _gameManager;

        public override void Update()
        {
            base.Update();

            if (_gameManager.CurrentState != GameState.PLAY) return;

            float time = Time.deltaTime;
            foreach (var item in _tickables)
                item.Tick(time);
        }

        public override void LateUpdate()
        {
            base.LateUpdate();
            
            if (_gameManager.CurrentState != GameState.PLAY) return;

            float time = Time.deltaTime;
            foreach (var item in _lateTickables)
                item.LateTick(time);
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            
            if (_gameManager.CurrentState != GameState.PLAY) return;

            float fixedTime = Time.fixedTime;
            foreach (var item in _fixedTickables)
                item.FixedTick(fixedTime);
        }
    }
}