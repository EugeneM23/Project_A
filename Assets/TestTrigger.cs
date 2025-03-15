using Game.Code.Infrastructure.Main;
using Game.Code.SoundSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class TestTrigger : MonoBehaviour
{
    [SerializeField] private string _level;
    [Inject] private SoundManager _soundManager;

    private void OnTriggerEnter(Collider other)
    {
        _soundManager.CleanUp();
        SceneManager.LoadScene(_level);
    }
}