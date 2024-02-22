using Cysharp.Threading.Tasks;

namespace FanShowcase.Utility.Loading
{
    public interface ILoadingService
    {
        UniTask Load(ILoadUnit loadUnit);
    }
}