using Cinemachine;
using UnityEngine;

namespace FanShowcase.Core.Scene
{
    [RequireComponent(typeof(CinemachineFreeLook))]
    [RequireComponent(typeof(CinemachineRecomposer))]
    public class SceneCameraHandler : MonoBehaviour
    {
        [SerializeField] private CinemachineFreeLook cinemachineFreeLook;
        [SerializeField] private CinemachineRecomposer cinemachineRecomposer;

        [SerializeField] private float minZoom = 0.2f;
        [SerializeField] private float maxZoom = 1f;
        [SerializeField] private string viewName = "General view";

        public CinemachineFreeLook FreeLook => cinemachineFreeLook;

        public CinemachineRecomposer Recomposer => cinemachineRecomposer;

        public float MinZoom => minZoom;

        public float MaxZoom => maxZoom;

        public string ViewName => viewName;

        private void Reset()
        {
            cinemachineFreeLook = GetComponent<CinemachineFreeLook>();
            cinemachineRecomposer = GetComponent<CinemachineRecomposer>();
        }
    }
}