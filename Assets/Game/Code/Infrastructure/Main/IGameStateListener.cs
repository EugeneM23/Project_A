namespace Game.Code.Infrastructure.Main
{
    public interface IGameStateListener
    {
    }

    public interface IGameStartListener : IGameStateListener
    {
        void OnStartGame();
    }

    public interface IGamePauseListener : IGameStateListener
    {
        void OnPauseGame();
    }

    public interface IGameResumListener : IGameStateListener
    {
        void OnResumeGame();
    }

    public interface IGameFinishListener : IGameStateListener
    {
        void OnFinishGame();
    }
}