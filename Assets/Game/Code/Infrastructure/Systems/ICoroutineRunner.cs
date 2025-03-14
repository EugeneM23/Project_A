using System.Collections;

namespace Game.Code.Infrastructure.Systems
{
    public interface ICoroutineRunner
    {
        void StartRoutine(IEnumerator load);
    }
}