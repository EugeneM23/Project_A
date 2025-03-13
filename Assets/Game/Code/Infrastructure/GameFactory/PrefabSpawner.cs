using System.Collections.Generic;
using Game.Code.GameLogick;
using Game.Code.UI;
using UnityEngine;
using Zenject;

namespace Game.Code.Infrastructure.GameFactory
{
    public class PrefabSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private GameObject _HUD;
        [SerializeField] private List<Enemy> _enemyPrefabs;

        private HUD.Factory _hudFactory;
        private Enemy.Factory _enemyFactory;

        [Inject]
        private void Construct( HUD.Factory HUDFactory, Enemy.Factory enemyFactory)
        {
            _hudFactory = HUDFactory;
            _enemyFactory = enemyFactory;
        }

        public void SpawnHUD() => _hudFactory.Create(_HUD);

        public void SpawnEnemys()
        {
            foreach (Enemy enemy in _enemyPrefabs)
            {
                Enemy unit = _enemyFactory.Create(enemy);
                
                Vector3 spawnPosition = Random.insideUnitSphere * 4;
                spawnPosition.y = 0;
                unit.transform.position = spawnPosition;
            }
        }
    }
}