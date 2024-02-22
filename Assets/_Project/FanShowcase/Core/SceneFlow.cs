using System.Linq;
using FanShowcase.Core.Scene;
using FanShowcase.UI.SceneHud;
using FanShowcase.Utility.Loading;
using JetBrains.Annotations;
using Zenject;

namespace FanShowcase.Core
{
    [UsedImplicitly]
    public class SceneFlow : IInitializable
    {
        private readonly ILoadingService _loadingService;
        private readonly ISceneHudController _sceneHudController;
        private readonly ISceneManager _sceneManager;
        private readonly SceneData _sceneData;

        public SceneFlow(ILoadingService loadingService,
            ISceneHudController sceneHudController,
            ISceneManager sceneManager,
            SceneData sceneData)
        {
            _loadingService = loadingService;
            _sceneHudController = sceneHudController;
            _sceneManager = sceneManager;
            _sceneData = sceneData;
        }
        
        public async void Initialize()
        {
            await _loadingService.Load(_sceneHudController);
            
            _sceneHudController.Construct(
                _sceneData.CameraSettings.Select(s => s.ViewName).ToList());
            
            _sceneManager.Start();
        }
    }
}