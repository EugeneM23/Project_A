using CI.QuickSave;
using UnityEngine;

namespace Game.Code.Infrastructure.Services
{
    public class PlayerProgressService
    {
        private const string Player = "Player";
        private const string Positiononlevel = "PositionOnlevel";
        private const string Health = "Health";
        private const string Currentweapon = "CurrentWeapon";
        private const string Level = "Level";

        public void Save(PlayerData playerData)
        {
            QuickSaveWriter writer = QuickSaveWriter.Create(Player);

            writer.Write(Positiononlevel, playerData.PositionOnlevel);
            writer.Write(Health, playerData.Health);
            writer.Write(Currentweapon, playerData.CurrentWeapon);
            writer.Write(Level, playerData.Level);

            writer.Commit();
        }

        public PlayerData Load()
        {
            if (QuickSaveReader.RootExists(Player) == false)
                return new PlayerData();

            QuickSaveReader reader = QuickSaveReader.Create(Player);
            PlayerData playerData = new PlayerData();

            playerData.PositionOnlevel = reader.Read<Vector3>(Positiononlevel);
            playerData.Level = reader.Read<string>(Level);
            playerData.CurrentWeapon = reader.Read<string>(Currentweapon);
            playerData.Health = reader.Read<int>(Health);

            return playerData;
        }

        public void Delete()
        {
            QuickSaveWriter.DeleteRoot(Player);
        }
    }
}