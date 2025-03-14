using Game.Code.Infrastructure.GameMachine;
using Game.Code.Infrastructure.Services;
using Zenject;

namespace Game.Code.Infrastructure.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<SoundManager.SoundManager>()
                .AsSingle().NonLazy();
            
            Container
                .Bind<PlayerProgressService>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<InputService>()
                .To<MobileInputService>()
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