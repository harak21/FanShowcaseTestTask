using System;
using FanShowcase.SceneManagement;
using FanShowcase.UI.MainMenu;
using FanShowcase.Utility.Configs;
using JetBrains.Annotations;
using Zenject;

namespace FanShowcase.MainMenu
{
    [UsedImplicitly]
    public class MainMenuFlow : IInitializable, IDisposable
    {
        private readonly IMainMenuUiController _mainMenuUiController;
        private readonly ISceneLoadService _sceneLoadService;

        [Inject]
        public MainMenuFlow(IMainMenuUiController mainMenuUiController,
            ISceneLoadService sceneLoadService)
        {
            _mainMenuUiController = mainMenuUiController;
            _sceneLoadService = sceneLoadService;
        }
        
        public void Initialize()
        {
            _mainMenuUiController.OnSceneSelected += LoadScene;
            _mainMenuUiController.HideLoadingCurtain();
        }

        private async void LoadScene(SceneConfig sceneConfig)
        {
            _mainMenuUiController.ShowLoadingCurtain();
            await _sceneLoadService.LoadScene(sceneConfig);
            _mainMenuUiController.Hide();
        }

        public void Dispose()
        {
            _mainMenuUiController.OnSceneSelected -= LoadScene;
        }
    }
}