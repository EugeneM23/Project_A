using Game.Code.GameLogick;
using Game.Code.GameLogick.Camera;
using Game.Code.GameLogick.Player;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Game.Code.Infrastructure.Installers
{
    public class SceneInstaller : MonoInstaller
    {
        [FormerlySerializedAs("_playerPrefab")] [SerializeField] private PlayerBase playerBasePrefab;

        public override void InstallBindings()
        {
            Container
                .Bind<IPlayer>()
                .To<PlayerBase>()
                .FromComponentInNewPrefab(playerBasePrefab)
                .AsSingle();
            
            Container.BindInterfacesAndSelfTo<CameraFolow>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerMoveController>().AsSingle().WithArguments(10f,10f).NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerAudioController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerDeathObserver>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GameManager>().AsSingle().NonLazy();

            /*
            Container
                .Bind<PrefabSpawner>()
                .FromComponentInHierarchy()
                .AsSingle()
                .NonLazy();

            Container
                .BindFactory<UnityEngine.Object, HUD, HUD.Factory>()
                .FromFactory<PrefabFactory<HUD>>();

            Container
                .BindFactory<UnityEngine.Object, Enemy, Enemy.Factory>()
                .FromFactory<PrefabFactory<Enemy>>();*/
        }
    }
}