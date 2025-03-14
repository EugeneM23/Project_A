using System;

namespace Game.Code.GameLogick.Player
{
    public interface IPlayer
    {
        public event Action OnDeath;
    }
}