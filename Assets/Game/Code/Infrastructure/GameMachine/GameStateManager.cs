using Game.Code.Infrastructure.Services;
using Zenject;

namespace Game.Code.Infrastructure.GameMachine
{
    public class GameStateManager : IInitializable
    {
        private readonly LazyInject<GameStateMachine> _stateMachine;
        private readonly PlayerProgressService _playerProgressService;

        public GameStateManager(LazyInject<GameStateMachine> stateMachine, PlayerProgressService playerProgressService)
        {
            _stateMachine = stateMachine;
            _playerProgressService = playerProgressService;
        }

        public void Initialize()
        {
            PlayerData progressData = _playerProgressService.Load();
            string level;

            if (progressData.Level == null)
                level = "L_Base";
            else
                level = progressData.Level;

            LoadLevel(level);
        }

        public void LoadLevel(string sceneName) => _stateMachine.Value.SetState<LoadLevelState, string>(sceneName);
    }
}