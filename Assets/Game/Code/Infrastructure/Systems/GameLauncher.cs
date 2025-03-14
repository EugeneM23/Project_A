using UnityEngine.SceneManagement;

namespace Game.Code.Infrastructure.Systems
{
    public class GameLauncher
    {
        public void StartGame() => SceneManager.LoadScene("L_Base");
    }
}