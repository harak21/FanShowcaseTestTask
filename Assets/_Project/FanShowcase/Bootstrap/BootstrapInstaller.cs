using FanShowcase.Input;
using FanShowcase.SceneManagement;
using FanShowcase.UI.MainMenu;
using FanShowcase.Utility.Configs;
using FanShowcase.Utility.Loading;
using Zenject;

namespace FanShowcase.Bootstrap
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IInputSystem>().To<PlayerInputSystem>().AsSingle();
            Container.Bind<ILoadingService>().To<LoadingService>().AsSingle();
            Container.Bind<IConfigContainer>().To<ConfigContainer>().AsSingle();
            Container.Bind<ISceneLoadService>().To<SceneLoadService>().AsSingle();
            Container.BindInterfacesTo<MainMenuUiController>().AsSingle();

            Container.BindInterfacesTo<BootstrapFlow>().AsSingle();
        }
    }
}