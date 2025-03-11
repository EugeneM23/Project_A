using System.Collections;

namespace Code.Infrastructure.GameMachine
{
    public interface ICoroutineRunner
    {
        void StartRoutine(IEnumerator load);
    }
}