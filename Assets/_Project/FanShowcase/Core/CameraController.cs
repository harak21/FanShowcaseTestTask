using System.Threading;
using Cysharp.Threading.Tasks;
using FanShowcase.Core.Scene;
using FanShowcase.Input;
using FanShowcase.Utility.Configs;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace FanShowcase.Core
{
    [UsedImplicitly]
    public class CameraController : ICameraController
    {
        private readonly IInputSystem _inputSystem;
        private readonly IConfigContainer _configContainer;
        private SceneCameraHandler _currentCamera;

        private CancellationTokenSource _tokenSource;
        private bool _isLookAround;

        [Inject]
        public CameraController(IInputSystem inputSystem, IConfigContainer configContainer)
        {
            _inputSystem = inputSystem;
            _configContainer = configContainer;
            inputSystem.OnZoomPerformed += ApplyZoom;
            inputSystem.OnLookStarted += LookAround;
            inputSystem.OnLookEnded += EndLook;
        }

        public void ChangeCamera(SceneCameraHandler cameraHandler)
        {
            if (_currentCamera is not null)
            {
                _currentCamera.gameObject.SetActive(false);
            }
            _currentCamera = cameraHandler;
            _currentCamera.gameObject.SetActive(true);
        }

        private void ApplyZoom(float zoomValue)
        {
            var scaledValue = Mathf.Clamp(zoomValue,
                -_configContainer.PlayerConfig.ZoomIntensity,
                _configContainer.PlayerConfig.ZoomIntensity);
            var delta = _currentCamera.Recomposer.m_ZoomScale - scaledValue;
            _currentCamera.Recomposer.m_ZoomScale = Mathf.Clamp(delta,
                _currentCamera.MinZoom,
                _currentCamera.MaxZoom);
        }

        private async void LookAround()
        {
            _isLookAround = true;
            while (_isLookAround)
            {
                var lookValue = _inputSystem.LookValue;
                _currentCamera.FreeLook.m_XAxis.m_InputAxisValue = Mathf.Clamp(
                    -lookValue.x, 
                    -_configContainer.PlayerConfig.LookAroundIntensity,
                    _configContainer.PlayerConfig.LookAroundIntensity);
                _currentCamera.FreeLook.m_YAxis.m_InputAxisValue = Mathf.Clamp(
                    -lookValue.y, 
                    -_configContainer.PlayerConfig.LookAroundIntensity,
                    _configContainer.PlayerConfig.LookAroundIntensity);
                await UniTask.Yield();
            }
            _currentCamera.FreeLook.m_XAxis.m_InputAxisValue = 0;
            _currentCamera.FreeLook.m_YAxis.m_InputAxisValue = 0;
        }

        private void EndLook()
        {
            _isLookAround = false;
        }
    }
}