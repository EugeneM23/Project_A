namespace Game.Code.Infrastructure.Main
{
    public interface IGameTickable
    {
        public void Tick(float deltaTime);
    }

    public interface IGameLateTickable
    {
        public void LateTick(float deltaTime);
    }

    public interface IGameFixedTickable
    {
        public void FixedTick(float FixedDeltaTime);
    }
}