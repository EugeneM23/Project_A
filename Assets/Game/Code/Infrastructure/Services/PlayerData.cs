using System;
using UnityEngine;

namespace Game.Code.Infrastructure.Services
{
    [Serializable]
    public class PlayerData
    {
        private const string LBase = "L_Base";
        private const string Weapon = "Pistol";
        public int Health { get; set; }
        public string Level { get; set; }
        public string CurrentWeapon { get; set; }
        public Vector3 PositionOnlevel { get; set; }

        public PlayerData()
        {
            PositionOnlevel = new Vector3(0, 0, 0);
            Level = LBase;
            Health = 100;
            CurrentWeapon = Weapon;
        }

        public PlayerData(Vector3 positionOnlevel, string level, int health, string currentWeapon)
        {
            PositionOnlevel = positionOnlevel;
            Level = level;
            Health = health;
            CurrentWeapon = currentWeapon;
        }
    }
}