using Zenject;

namespace Game.Code.Infrastructure.GameMachine
{
    public class StartState : IState
    {
        private readonly LazyInject<GameStateMachine> _stateMachine;

        public StartState(LazyInject<GameStateMachine> gameStateMachine)
        {
            _stateMachine = gameStateMachine;
        }

        public void Exit()
        {
        }

        public void Enter()
        {
            _stateMachine.Value.SetState<LoadLevelState, string>("L_Base");
        }
    }
}