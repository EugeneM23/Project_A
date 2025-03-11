using System.Collections;
using UnityEngine;

namespace Game.Code.Infrastructure.GameMachine
{
    public class CoroutineRunner : MonoBehaviour, ICoroutineRunner
    {
        public void StartRoutine(IEnumerator load) => StartCoroutine(load);
    }
}