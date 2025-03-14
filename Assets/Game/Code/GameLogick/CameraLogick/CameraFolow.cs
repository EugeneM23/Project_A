using Game.Code.GameLogick.Player;
using UnityEngine;
using Zenject;

namespace Game.Code.GameLogick.CameraLogick
{
    public class CameraFolow : ILateTickable, IInitializable
    {
        private Camera _camera;
        private Vector3 _offset;
        private Transform _target;

        public CameraFolow(IPlayer player) => _target = (player as PlayerBase).gameObject.transform;

        public void Initialize()
        {
            _camera = UnityEngine.Camera.main;
            _offset = _camera.transform.position;
        }

        public void LateTick() => _camera.transform.position = _offset + _target.position;
    }
}