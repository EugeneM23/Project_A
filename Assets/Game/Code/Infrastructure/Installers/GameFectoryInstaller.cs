using UnityEngine;
using Zenject;

namespace Code.FactoryPrefab
{
    public class GameFectoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<UnitSpawner>()
                .FromComponentInHierarchy()
                .AsSingle()
                .NonLazy();

            Container
                .BindFactory<GameObject, MonoBehaviour, PrefabFactory>()
                .FromFactory<CustomPrefabFactory>();
        }
    }
}