using UnityEngine;
using Zenject;

namespace Code.Infrastructure.GameMachine
{
    public class GameplayState : IState
    {
        private readonly LazyInject<GameStateMachine> _stateMachine;

        public GameplayState(LazyInject<GameStateMachine> stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            Debug.Log("Entering Gameplay State");
        }

        public void Exit()
        {
            Debug.Log("Exiting Gameplay State");
        }
    }
}