using FanShowcase.SceneManagement;
using FanShowcase.UI.MainMenu;
using FanShowcase.Utility.Configs;
using FanShowcase.Utility.Loading;
using Zenject;

namespace FanShowcase.Bootstrap
{
    public class BootstrapFlow : IInitializable
    {
        private readonly ILoadingService _loadingService;
        private readonly IConfigContainer _configContainer;
        private readonly ISceneLoadService _sceneLoadService;
        private readonly IMainMenuUiController _mainMenuUiController;

        [Inject]
        public BootstrapFlow(ILoadingService loadingService,
            IConfigContainer configContainer,
            ISceneLoadService sceneLoadService,
            IMainMenuUiController mainMenuUiController)
        {
            _mainMenuUiController = mainMenuUiController;
            _loadingService = loadingService;
            _configContainer = configContainer;
            _sceneLoadService = sceneLoadService;
        }
        
        public async void Initialize()
        {
            await _loadingService.Load(_mainMenuUiController);
            _mainMenuUiController.ShowLoadingCurtain();
            await _loadingService.Load(_configContainer);
            await _sceneLoadService.LoadMainMenu();
            _mainMenuUiController.Construct();
        }
    }
}