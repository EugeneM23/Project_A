using Code.Infrastructure.GameMachine;
using Code.Infrastructure.Services;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class GameStateMachineInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
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