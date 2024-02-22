using FanShowcase.Core.Scene;
using FanShowcase.UI.SceneHud;
using UnityEngine;
using Zenject;

namespace FanShowcase.Core
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private SceneData sceneData = new();
        
        public override void InstallBindings()
        {
            Container.BindInstance(sceneData).AsSingle();
            Container.BindInterfacesTo<SceneHudController>().AsSingle();
            Container.BindInterfacesTo<SceneManager>().AsSingle();
            Container.Bind<ICameraController>().To<CameraController>().AsSingle();
            
            Container.BindInterfacesTo<SceneFlow>().AsSingle();
        }
    }
}