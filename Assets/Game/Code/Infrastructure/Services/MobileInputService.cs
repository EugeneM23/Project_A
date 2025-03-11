using UnityEngine;

namespace Game.Code.Infrastructure.Services
{
    public class MobileInputService : InputService
    {
        public override Vector3 Axis => GetAxisFromSimpleInput();
    }
}