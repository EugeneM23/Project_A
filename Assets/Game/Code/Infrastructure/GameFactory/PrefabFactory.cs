using UnityEngine;
using Zenject;

namespace Game.Code
{
    public class PrefabFactory<T> : IFactory<Object, T> where T : MonoBehaviour
    {
        readonly DiContainer _container;

        public PrefabFactory(DiContainer container)
        {
            _container = container;
        }

        public T Create(Object prefab)
        {
            return _container.InstantiatePrefabForComponent<T>(prefab);
        }
    }
}