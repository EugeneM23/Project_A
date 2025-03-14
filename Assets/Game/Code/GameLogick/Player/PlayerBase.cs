using System;
using UnityEngine;

namespace Game.Code.GameLogick.Player
{
    public class PlayerBase : MonoBehaviour, IPlayer
    {
        public event Action OnDeath;
    }
}