using UnityEngine;

namespace Code.Infrastructure.Services
{
    public class MobileInputService : InputService
    {
        public override Vector3 Axis => GetAxisFromSimpleInput();
    }
}