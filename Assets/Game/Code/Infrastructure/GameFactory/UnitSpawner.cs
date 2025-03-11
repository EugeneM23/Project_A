using Code;
using Code.FactoryPrefab;
using UnityEngine;
using Zenject;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject _HUD;

    [Inject] PrefabFactory _plaFactory;
    public Transform SpawnPlayer()
    {
        //_plaFactory.Create(_HUD);
        
        Transform player = _plaFactory.Create(_playerPrefab).transform;
        Camera.main.GetComponent<CameraFolow>().SetTarget(player);
        Instantiate(Resources.Load("UI/HUD"));
        return player;
    }
}