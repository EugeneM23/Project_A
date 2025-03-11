using UnityEngine;
using Zenject;

namespace Code.FactoryPrefab
{
    public class CustomPrefabFactory : IFactory<GameObject, MonoBehaviour>
    {
        readonly DiContainer _container;

        public CustomPrefabFactory(DiContainer container)
        {
            _container = container;
        }

        public MonoBehaviour Create(GameObject prefab)
        {
            return _container.InstantiatePrefabForComponent<MonoBehaviour>(prefab);
        }
    }

    public class PrefabFactory : PlaceholderFactory<GameObject, MonoBehaviour>
    {
    }
}