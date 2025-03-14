using System;
using UnityEngine;
using Input = UnityEngine.Windows.Input;

namespace Game.Code.GameLogick.Player
{
    public class PlayerBase : MonoBehaviour, IPlayer
    {
        public event Action OnDeath;
    }
}