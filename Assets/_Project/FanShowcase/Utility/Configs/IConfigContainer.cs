using FanShowcase.Utility.Loading;

namespace FanShowcase.Utility.Configs
{
    public interface IConfigContainer : ILoadUnit
    {
        ScenesConfigRepository ScenesConfigRepository { get; }
        PlayerConfig PlayerConfig { get; }
    }
}