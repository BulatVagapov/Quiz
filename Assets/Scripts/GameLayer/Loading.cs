using Cysharp.Threading.Tasks;
using System;

namespace Quiz.GameLayer
{
    public class Loading
    {
        public float LoadingTimeInSeconds { get; private set; }
        public event Action LoadingIsOverEvent;

        public Loading(float loadingTime)
        {
            LoadingTimeInSeconds = loadingTime;
        }

        private async UniTask LoadingAsync(float loadingTimeInSeconds)
        {
            await UniTask.Delay((int)LoadingTimeInSeconds * 1000);
            LoadingIsOverEvent?.Invoke();
        }

        public void StartLoading()
        {
            LoadingAsync(LoadingTimeInSeconds).Forget();
        }
    }
}