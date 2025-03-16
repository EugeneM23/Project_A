using System.Threading.Tasks;

namespace Game.Code.Infrastructure.SceneLoadComposite
{
    public interface ILoadingStep
    {
        Task Execute();
    }
}