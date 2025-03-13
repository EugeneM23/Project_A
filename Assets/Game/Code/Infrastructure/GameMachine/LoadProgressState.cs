using Game.Code.Infrastructure.GameFactory;
using Game.Code.Infrastructure.GameMachine;
using Game.Code.Infrastructure.Services;
using UnityEngine;

public class LoadProgressState : LoadStateBase
{
    private readonly PlayerProgressService _playerProgressService;

    public LoadProgressState(SceneLoader sceneLoader, SoundManager soundManager, PlayerProgressService playerProgressService) 
        : base(sceneLoader, soundManager)
    {
        _playerProgressService = playerProgressService;
    }

    protected override Transform SpawnPlayer(PrefabSpawner unitFactory)
    {
        PlayerData playerData = _playerProgressService.Load();
        return unitFactory.SpawnPlayer(at: playerData.PositionOnlevel);
    }
}