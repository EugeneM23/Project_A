using System;
using UnityEditor;
using UnityEngine;

namespace Game.Code.Infrastructure.GameMachine
{
    internal class PlayerSpawnPoint : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.position, new Vector3(1, 1, 1));
        }
    }
}