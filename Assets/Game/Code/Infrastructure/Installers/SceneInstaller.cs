using Game.Code.Infrastructure.Main;
using Game.Code.Infrastructure.Systems;
using Game.Code.UI;
using UnityEngine;
using Zenject;

namespace Game.Code.Infrastructure.Installers
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private HUD _hud;
        [SerializeField] private StartScreen _startScreen;
        [SerializeField] private PauseScreen _pauseScreen;
        [SerializeField] private FinishScreen _finishScreen;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<HUD>()
                .FromInstance(_hud)
                .AsCached()
                .NonLazy();

            Container
                .BindInterfacesTo<StartScreen>()
                .FromInstance(_startScreen)
                .AsCached()
                .NonLazy();

            Container
                .BindInterfacesTo<PauseScreen>()
                .FromInstance(_pauseScreen)
                .AsCached()
                .NonLazy();

            Container
                .BindInterfacesTo<FinishScreen>()
                .FromInstance(_finishScreen)
                .AsCached()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<GameStateManager>()
                .AsCached()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<GameStateController>()
                .AsCached()
                .NonLazy();
        }
    }
}