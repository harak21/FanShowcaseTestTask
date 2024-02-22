using System;
using Cysharp.Threading.Tasks;
using FanShowcase.Utility.Loading;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace FanShowcase.Utility.Configs
{
    [Serializable]
    public class SceneConfig : ILoadUnit
    {
        [SerializeField] private int id;
        [SerializeField] private string addressableName;
        [SerializeField] private Sprite scenePreview;

        public int ID => id;

        public Sprite ScenePreview => scenePreview;

        public async UniTask Load()
        {
            await Addressables.LoadSceneAsync(addressableName).Task;
        }
    }
}