using FanShowcase.Core.Scene;
using FanShowcase.Input;
using FanShowcase.UI.SceneHud;
using JetBrains.Annotations;
using Zenject;

namespace FanShowcase.Core
{
    [UsedImplicitly]
    public class SceneManager : ISceneManager
    {
        private readonly ICameraController _cameraController;
        private readonly ISceneHudController _sceneHudController;
        private readonly SceneData _sceneData;
        private readonly IInputSystem _inputSystem;

        [Inject]
        public SceneManager(ICameraController cameraController,
            ISceneHudController sceneHudController,
            SceneData sceneData)
        {
            _cameraController = cameraController;
            _sceneHudController = sceneHudController;
            _sceneData = sceneData;
            _sceneHudController.OnViewSelected += SelectNewView;
        }

        public void Start()
        {
            _cameraController.ChangeCamera(_sceneData.CameraSettings[0]);
        }

        private void SelectNewView(int viewIndex)
        {
            _cameraController.ChangeCamera(_sceneData.CameraSettings[viewIndex]);
        }

        public void Dispose()
        {
            _sceneHudController.OnViewSelected -= SelectNewView;
        }
    }
}