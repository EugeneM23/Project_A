using UnityEngine;
using Zenject;

namespace Game.Code.UI
{
    public class HUD : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<Object, HUD>
        {
        }
    }
}