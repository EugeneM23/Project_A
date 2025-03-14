using Game.Code.GameLogick.Player;
using UnityEngine;
using Zenject;

namespace Game.Code.GameLogick.Camera
{
    public class CameraFolow : ILateTickable, IInitializable
    {
        private UnityEngine.Camera _camera;
        private Vector3 _offset;
        private Transform _target;

        public CameraFolow(IPlayer player)
        {
            Player.PlayerBase playerBaseComponent = player as Player.PlayerBase;
            _target = playerBaseComponent.gameObject.transform;
        }

        public void Initialize()
        {
            _camera = UnityEngine.Camera.main;
            _offset = _camera.transform.position;
        }

        public void LateTick() => _camera.transform.position = _offset + _target.position;
    }
}