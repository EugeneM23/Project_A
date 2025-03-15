using Game.Code.Infrastructure.Systems;
using Game.Code.UI;
using UnityEngine;
using Zenject;

namespace Game.Code.Infrastructure.Installers
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private HUD _hud;
        public override void InstallBindings()
        {
            Container.Bind<HUD>().FromComponentInNewPrefab(_hud).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<Timer>().AsSingle().NonLazy();
        }
    }
}