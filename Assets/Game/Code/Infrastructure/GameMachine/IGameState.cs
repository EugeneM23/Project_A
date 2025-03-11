namespace Code.Infrastructure.GameMachine
{
    public interface IGameState
    {
        public void Enter();
        
        public void Exit();
    }
}