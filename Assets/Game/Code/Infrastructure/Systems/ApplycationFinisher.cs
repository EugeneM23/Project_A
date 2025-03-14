namespace Game.Code.Infrastructure.Systems
{
    public class ApplycationFinisher
    {
        public void FinishGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
Application.Quit();
#endif
        }
    }
}