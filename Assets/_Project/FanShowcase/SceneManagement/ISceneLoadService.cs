using Cysharp.Threading.Tasks;
using FanShowcase.Utility.Configs;

namespace FanShowcase.SceneManagement
{
    public interface ISceneLoadService
    {
        UniTask LoadScene(SceneConfig sceneConfig);
        UniTask LoadMainMenu();
    }
}