using System;
using UnityEngine;
using Zenject;

namespace Game.Code.GameLogick.Enemys
{
    [Serializable]
    public abstract class Enemy : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<UnityEngine.Object, Enemy>
        {
        }
    }
}