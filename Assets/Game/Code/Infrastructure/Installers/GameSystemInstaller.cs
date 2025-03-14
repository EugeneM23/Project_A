using Game.Code.GameLogick.Player;
using Game.Code.Infrastructure.Services;
using Game.Code.Infrastructure.Systems;
using Game.Code.SoundSystem;
using UnityEngine;
using Zenject;

namespace Game.Code.Infrastructure.Installers
{
    [CreateAssetMenu (fileName = "GameSystemInstaller", menuName = "Installers/GameSystemInstaller")]
    public class GameSystemInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<SoundManager>()
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
            
            Container
                .BindInterfacesAndSelfTo<GameManager>()
                .AsSingle()
                .NonLazy();
            
            Container.Bind<ApplycationFinisher>().AsSingle().NonLazy();
            Container.Bind<GameLauncher>().AsSingle().NonLazy();
            Container.BindInterfacesTo<GameExitController>().AsSingle().NonLazy();

        }
    }
}