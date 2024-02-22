using System;
using System.Diagnostics;
using System.Threading;
using Cysharp.Threading.Tasks;
using FanShowcase.Utility.Logging;
using JetBrains.Annotations;

namespace FanShowcase.Utility.Loading
{
    [UsedImplicitly]
    public class LoadingService : ILoadingService
    {
        private readonly Stopwatch _watch = new();
        
        public async UniTask Load(ILoadUnit loadUnit)
        {
            var isError = true;

            try
            {
                OnLoadingBegin(loadUnit);
                await loadUnit.Load();
                isError = false;
            }
            catch (Exception e)
            {
                Log.Loading.E(e);
                throw;
            }
            finally
            {
                await OnLoadingFinish(loadUnit, isError);
            }
        }
        
        private void OnLoadingBegin(object unit)
        {
            _watch.Restart();
            Log.Loading.D($"{unit.GetType().Name} loading is started");
        }
        
        private async UniTask OnLoadingFinish(object unit, bool isError)
        {            
            _watch.Stop();
            Log.Loading.D($"{unit.GetType().Name} is {(isError ? "NOT " : "")}loaded with time {_watch.ElapsedMilliseconds}ms");

            int currentThreadId = Thread.CurrentThread.ManagedThreadId;
            int mainThreadId = PlayerLoopHelper.MainThreadId;

            if (mainThreadId != currentThreadId) {
                _watch.Restart();
                Log.Loading.D($"[THREAD] start switching from '{currentThreadId}' thread to main thread '{mainThreadId}'");
                await UniTask.SwitchToMainThread();
                _watch.Stop();
                Log.Loading.D($"[THREAD] switch finished with time {_watch.ElapsedMilliseconds}");
            }
        }
    }
}