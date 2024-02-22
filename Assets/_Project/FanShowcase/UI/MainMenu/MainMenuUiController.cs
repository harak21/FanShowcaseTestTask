using System;
using Cysharp.Threading.Tasks;
using FanShowcase.Utility;
using FanShowcase.Utility.Configs;
using JetBrains.Annotations;
using UniRx;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace FanShowcase.UI.MainMenu
{
    [UsedImplicitly]
    public class MainMenuUiController : IMainMenuUiController
    {
        public event Action<SceneConfig> OnSceneSelected;

        private readonly IConfigContainer _scenesConfig;

        private readonly CompositeDisposable _disposable = new();
        
        private MainMenuView _mainMenuView;
        private ScenePreviewButton _scenePreviewPrefab;

        [Inject]
        public MainMenuUiController(IConfigContainer configContainer)
        {
            _scenesConfig = configContainer;
        }

        public async UniTask Load()
        {
            var menuAsset = await AssetService.R.Load<GameObject>(RuntimeConstants.Addressables.MainMenuView);
            _mainMenuView = Object.Instantiate(menuAsset).GetComponent<MainMenuView>();
            _scenePreviewPrefab = (await AssetService.R.Load<GameObject>(RuntimeConstants.Addressables.ScenePreviewButton))
                .GetComponent<ScenePreviewButton>();
            Object.DontDestroyOnLoad(_mainMenuView);
        }

        public void Construct()
        {
            for (var i = 0; i < _scenesConfig.ScenesConfigRepository.SceneConfigs.Count; i++)
            {
                var sceneConfig = _scenesConfig.ScenesConfigRepository.SceneConfigs[i];
                var scenePreview = Object.Instantiate(_scenePreviewPrefab);
                scenePreview.SetPreview(sceneConfig.ScenePreview);
                _mainMenuView.AddButton(scenePreview.Button);
                var localI = i;
                scenePreview.Button.onClick
                    .AsObservable()
                    .Subscribe(_ => OnSceneChosen(localI))
                    .AddTo(_disposable);
            }
        }

        public void ShowLoadingCurtain()
        {
            _mainMenuView.ShowLoadingCurtain();
        }

        public void HideLoadingCurtain()
        {
            _mainMenuView.HideLoadingCurtain();
        }

        public void Hide()
        {
            _mainMenuView.Hide();
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }

        private void OnSceneChosen(int sceneIndex)
        {
            var scene = _scenesConfig.ScenesConfigRepository.SceneConfigs[sceneIndex];
            OnSceneSelected?.Invoke(scene);
        }
    }
}