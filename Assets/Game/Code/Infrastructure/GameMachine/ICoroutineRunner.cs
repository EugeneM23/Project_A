using System.Collections;

namespace Game.Code.Infrastructure.GameMachine
{
    public interface ICoroutineRunner
    {
        void StartRoutine(IEnumerator load);
    }
}