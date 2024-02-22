using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine.AddressableAssets;

namespace FanShowcase.Utility
{
    [UsedImplicitly]
    public class AssetService
    {
        public static Resources R { get; } = new();
    }
    public sealed class Resources
    {
        public async UniTask<T> Load<T>(string path)
        {
            var handle = Addressables.LoadAssetAsync<T>(path);
            return await handle.Task;
        }
    }
}