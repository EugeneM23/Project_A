using Game.Code.GameLogick.Player;
using Game.Code.Infrastructure.Main;
using UnityEngine;
using Zenject;

namespace Game.Code.GameLogick.CameraLogick
{
    public class CameraFolow : IGameLateTickable, IInitializable
    {
        private Camera _camera;
        private Vector3 _offset;
        private Transform _target;
        private bool _isMovable;
        public CameraFolow(PlayerBase player) => _target =  player.gameObject.transform;

        public void Initialize()
        {
            _camera = Camera.main;
            _offset = _camera.transform.position;
        }

        public void LateTick(float deltaTime) => _camera.transform.position = _offset + _target.position;
    }
}