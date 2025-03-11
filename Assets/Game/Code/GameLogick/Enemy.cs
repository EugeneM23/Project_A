using System;
using UnityEngine;
using Zenject;

namespace Game.Code.GameLogick
{
    [Serializable]
    public abstract class Enemy : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<UnityEngine.Object, Enemy>
        {
        }
    }
}