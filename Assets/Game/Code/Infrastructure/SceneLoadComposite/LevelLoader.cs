using System.Collections.Generic;
using System.Threading.Tasks;

namespace Game.Code.Infrastructure.SceneLoadComposite
{
    public class LevelLoader
    {
        private List<ILoadingStep> steps = new List<ILoadingStep>();

        public void AddStep(ILoadingStep step)
        {
            steps.Add(step);
        }

        public async Task LoadLevel()
        {
            foreach (var step in steps)
            {
                await step.Execute();
            }
        }
    }
}