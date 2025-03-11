using UnityEngine;

namespace Game.Code.Infrastructure.Services
{
    public abstract class InputService : IService
    {
        protected const string Vertical = "Vertical";
        protected const string Horizontal = "Horizontal";

        public abstract Vector3 Axis { get; }

        protected Vector3 GetAxisFromSimpleInput()
        {
            return new Vector3(SimpleInput.GetAxis(Horizontal), 0, SimpleInput.GetAxis(Vertical));
        }
    }
}