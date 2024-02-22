using Cysharp.Threading.Tasks;
using FanShowcase.Utility.Configs;
using FanShowcase.Utility.Loading;
using JetBrains.Annotations;
using Zenject;

namespace FanShowcase.SceneManagement
{
    [UsedImplicitly]
    public class SceneLoadService : ISceneLoadService
    {
        private readonly ILoadingService _loadingService;
        private readonly IConfigContainer _configContainer;

        [Inject]
        public SceneLoadService(ILoadingService loadingService, IConfigContainer configContainer)
        {
            _loadingService = loadingService;
            _configContainer = configContainer;
        }
        
        public UniTask LoadScene(SceneConfig sceneConfig)
        {
            return _loadingService.Load(sceneConfig);
        }

        public UniTask LoadMainMenu()
        {
            return _loadingService.Load(_configContainer.ScenesConfigRepository.MainMenu);
        }
    }
}