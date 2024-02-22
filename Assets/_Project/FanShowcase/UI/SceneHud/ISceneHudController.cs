using System;
using System.Collections.Generic;
using FanShowcase.Utility.Loading;

namespace FanShowcase.UI.SceneHud
{
    public interface ISceneHudController : ILoadUnit, IDisposable
    {
        event Action<int> OnViewSelected;
        void Construct(List<string> buttonNames);
    }
}