using System;
using FanShowcase.Utility.Configs;
using FanShowcase.Utility.Loading;

namespace FanShowcase.UI.MainMenu
{
    public interface IMainMenuUiController : ILoadUnit, IDisposable
    {
        event Action<SceneConfig> OnSceneSelected;
        void Construct();
        void ShowLoadingCurtain();
        void HideLoadingCurtain();
        void Hide();
    }
}