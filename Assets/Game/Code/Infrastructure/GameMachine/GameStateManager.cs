using Zenject;

namespace Game.Code.Infrastructure.GameMachine
{
    public class GameStateManager : IInitializable
    {
        private readonly LazyInject<GameStateMachine> _stateMachine;

        public GameStateManager(LazyInject<GameStateMachine> stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Initialize() => LoadLevel("L_Base");

        public void LoadLevel(string sceneName) => _stateMachine.Value.SetState<LoadLevelState, string>(sceneName);
    }
}