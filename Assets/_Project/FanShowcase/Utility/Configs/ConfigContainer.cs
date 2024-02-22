using Cysharp.Threading.Tasks;
using JetBrains.Annotations;

namespace FanShowcase.Utility.Configs
{
    [UsedImplicitly]
    public class ConfigContainer : IConfigContainer
    {
        public ScenesConfigRepository ScenesConfigRepository { get; private set; }
        public PlayerConfig PlayerConfig { get; private set; }
        
        public async UniTask Load()
        {
            ScenesConfigRepository =
                await AssetService.R.Load<ScenesConfigRepository>(RuntimeConstants.Addressables.ScenesConfigRepository);
            PlayerConfig =
                (await AssetService.R.Load<PlayerConfigRepository>(
                    RuntimeConstants.Addressables.PlayerConfigRepository)).Config;
        }
    }
}