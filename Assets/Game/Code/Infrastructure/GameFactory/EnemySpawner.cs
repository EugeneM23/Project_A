using System.Collections.Generic;
using Game.Code.GameLogick.Enemys;
using UnityEngine;
using Zenject;

namespace Game.Code.Infrastructure.GameFactory
{
    public class EnemySpawner
    {
        [SerializeField] private List<Enemy> _enemyPrefabs;

        public void SpawnEnemys()
        {
            foreach (Enemy enemy in _enemyPrefabs)
            {
            }
        }
    }
}