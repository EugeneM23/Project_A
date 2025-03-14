using Game.Code.Infrastructure.Systems;
using Game.Code.UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Code.Infrastructure.Installers
{
    public class MenuInstaller : MonoInstaller
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _finishButton;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<StartGameButton>()
                .AsSingle()
                .WithArguments(_startButton);

            Container
                .BindInterfacesAndSelfTo<FinishGameButton>()
                .AsSingle()
                .WithArguments(_finishButton);
            

        }
    }
}