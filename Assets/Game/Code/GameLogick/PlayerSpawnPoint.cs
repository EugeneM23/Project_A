using UnityEngine;

namespace Game.Code.GameLogick
{
    internal class PlayerSpawnPoint : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.position, new Vector3(2f, 0.3f, 2f));
        }
    }
}