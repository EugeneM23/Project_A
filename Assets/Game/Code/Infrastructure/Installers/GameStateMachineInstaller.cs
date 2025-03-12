using Game.Code.Infrastructure.GameMachine;
using Game.Code.Infrastructure.Services;
using Zenject;

namespace Game.Code.Infrastructure.Installers
{
    public class GameStateMachineInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerProgressService>().AsSingle().NonLazy();

            Container
                .Bind<GameStateMachine>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<InputService>()
                .To<MobileInputService>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<GameStateManager>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<IBaseState>()
                .To<StartState>()
                .AsSingle()
                .NonLazy();
            
            Container
                .Bind<IBaseState>()
                .To<LoadProgressState>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<IBaseState>()
                .To<LoadLevelState>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<IBaseState>()
                .To<GameplayState>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<SceneLoader>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<ICoroutineRunner>()
                .To<CoroutineRunner>()
                .FromNewComponentOnNewGameObject()
                .AsSingle()
                .NonLazy();
            
            
        }
    }
}