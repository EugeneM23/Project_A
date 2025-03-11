using Game.Code.GameLogick;
using Game.Code.Infrastructure.GameFactory;
using Game.Code.UI;
using Zenject;

namespace Game.Code.Infrastructure.Installers
{
    public class GameFectoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<PrefabSpawner>()
                .FromComponentInHierarchy()
                .AsSingle()
                .NonLazy();

            Container
                .BindFactory<UnityEngine.Object, Player, Player.Factory>()
                .FromFactory<PrefabFactory<Player>>();
            
            Container
                .BindFactory<UnityEngine.Object, HUD, HUD.Factory>()
                .FromFactory<PrefabFactory<HUD>>();
            
            Container
                .BindFactory<UnityEngine.Object, Enemy, Enemy.Factory>()
                .FromFactory<PrefabFactory<Enemy>>();
        }
    }
}