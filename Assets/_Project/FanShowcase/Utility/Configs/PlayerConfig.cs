using System;
using UnityEngine;

namespace FanShowcase.Utility.Configs
{
    [Serializable]
    public class PlayerConfig
    {
        [SerializeField] private float zoomIntensity = 0.2f;
        [SerializeField] private float lookAroundIntensity = 1.3f;

        public float ZoomIntensity => zoomIntensity;

        public float LookAroundIntensity => lookAroundIntensity;
    }
}