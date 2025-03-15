using Game.Code.Infrastructure.Main;
using UnityEngine;
using Zenject;

namespace Game.Code.UI
{
    public class FinishScreen : MonoBehaviour, IGameFinishListener, IInitializable
    {
        public void OnFinishGame() => gameObject.SetActive(true);

        public void Initialize() => gameObject.SetActive(false);
    }
}