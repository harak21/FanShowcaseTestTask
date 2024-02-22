using Cysharp.Threading.Tasks;

namespace FanShowcase.Utility.Loading
{
    public interface ILoadUnit
    {
        public UniTask Load();
    }
}