using Game.Code.GameLogick;
using Game.Code.GameLogick.CameraLogick;
using Game.Code.GameLogick.Player;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Game.Code.Infrastructure.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerBase playerBasePrefab;

        public override void InstallBindings()
        {
            Container
                .Bind<IPlayer>()
                .To<PlayerBase>()
                .FromComponentInNewPrefab(playerBasePrefab)
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