using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using FanShowcase.Utility;
using JetBrains.Annotations;
using UniRx;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace FanShowcase.UI.SceneHud
{
    [UsedImplicitly]
    public class SceneHudController : ISceneHudController
    {
        public event Action<int> OnViewSelected;

        private readonly CompositeDisposable _disposable = new();
        
        private SceneHudView _sceneHudView;
        private CameraViewButton _cameraViewButtonPrefab;

        [Inject]
        public SceneHudController()
        {
            
        }
        
        public async UniTask Load()
        {
            var hudAsset = await AssetService.R.Load<GameObject>(RuntimeConstants.Addressables.SceneHudView);
            _sceneHudView = Object.Instantiate(hudAsset).GetComponent<SceneHudView>();
            _cameraViewButtonPrefab = (await AssetService.R.Load<GameObject>(RuntimeConstants.Addressables.CameraViewButton))
                .GetComponent<CameraViewButton>();
        }

        public void Construct(List<string> buttonNames)
        {
            for (var i = 0; i < buttonNames.Count; i++)
            {
                var buttonName = buttonNames[i];
                var cameraViewButton = Object.Instantiate(_cameraViewButtonPrefab);
                cameraViewButton.SetViewName(buttonName);
                _sceneHudView.AddViewButton(cameraViewButton.Button);
                var localI = i;
                cameraViewButton.Button.onClick
                    .AsObservable()
                    .Subscribe(_ => SelectNewView(localI))
                    .AddTo(_disposable);
            }
        }

        private void SelectNewView(int localI)
        {
            OnViewSelected?.Invoke(localI);
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}