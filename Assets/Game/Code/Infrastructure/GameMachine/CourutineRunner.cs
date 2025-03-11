using System;
using System.Collections;
using Code.Infrastructure.GameMachine;
using UnityEngine;

namespace Code.Infrastructure
{
    public class CoroutineRunner : MonoBehaviour, ICoroutineRunner
    {
        public void StartRoutine(IEnumerator load) => StartCoroutine(load);
    }
}