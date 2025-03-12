using System;
using Game.Code.Infrastructure.GameMachine;
using UnityEngine;
using Zenject;

public class TestTrigger : MonoBehaviour
{
    [SerializeField] string _level;
    private GameStateMachine _stateMachine;

    void Start()
    {
        _stateMachine = ProjectContext.Instance.Container.Resolve<GameStateMachine>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _stateMachine.SetState<LoadLevelState, string>(_level);
    }
}