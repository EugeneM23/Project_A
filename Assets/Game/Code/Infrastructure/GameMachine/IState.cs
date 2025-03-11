namespace Game.Code.Infrastructure.GameMachine
{
    public interface IState : IBaseState
    {
        public void Enter();
    }

    public interface IPayLoadState<PayLoad> : IBaseState
    {
        public void Enter(PayLoad scene);
    }

    public interface IBaseState
    {
        public void Exit();
    }
}