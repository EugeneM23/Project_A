using System;
using Game.Code.Infrastructure.Services;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Code.GameLogick.Player
{
    public class PlayerBase : MonoBehaviour
    {
        public event Action OnDeath;
        public int Health = 100;
        public string CurrentWeapon = "Pistol";

        public PlayerData GetData()
        {
            PlayerData data = new PlayerData();
            data.Health = Health;
            data.Level = SceneManager.GetActiveScene().name;
            data.PositionOnlevel = transform.position;
            data.CurrentWeapon = CurrentWeapon;
            
            Debug.Log(data.Level);
            Debug.Log(data.Health);
            Debug.Log(data.Level);
            Debug.Log(data.Level);
            Debug.Log(data.Level);
            return data;
        }

        public void LoadData(PlayerData data)
        {
            Debug.Log("Asdasdsad");
            Health = data.Health;
            CurrentWeapon = data.CurrentWeapon;
            
            gameObject.GetComponent<CharacterController>().enabled = false;
            transform.position = data.PositionOnlevel;
            gameObject.GetComponent<CharacterController>().enabled = true;
        }
    }
}