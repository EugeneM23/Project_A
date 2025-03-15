using Game.Code.GameLogick.CameraLogick;
using Game.Code.GameLogick.Player;
using Game.Code.Infrastructure.Main;
using UnityEngine;
using Zenject;

namespace Game.Code.Infrastructure.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerBase playerBasePrefab;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameSvaLoadController>().AsSingle().NonLazy();
            
            Container
                .Bind<PlayerBase>().FromComponentInNewPrefab(playerBasePrefab)
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<CameraFolow>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<PlayerMoveController>()
                .AsSingle()
                .WithArguments(10f, 20f)
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<PlayerAudioController>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<PlayerDeathObserver>()
                .AsSingle()
                .NonLazy();
        }
    }
}