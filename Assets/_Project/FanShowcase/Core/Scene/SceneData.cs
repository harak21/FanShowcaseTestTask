using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace FanShowcase.Core.Scene
{
    public class SceneData : MonoBehaviour
    {
        [SerializeField] private List<SceneCameraHandler> cameraSettings = new();

        public ReadOnlyCollection<SceneCameraHandler> CameraSettings => cameraSettings.AsReadOnly();
    }
}