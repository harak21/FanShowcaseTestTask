using Zenject;

namespace FanShowcase.MainMenu
{
    public class MainMenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<MainMenuFlow>().AsSingle();
        }
    }
}