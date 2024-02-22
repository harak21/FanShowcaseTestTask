using System;
using UnityEngine;

namespace FanShowcase.Input
{
    public interface IInputSystem
    {
        event Action<float> OnZoomPerformed;
        event Action OnLookStarted;
        event Action OnLookEnded;
        Vector2 LookValue { get; }
    }
}