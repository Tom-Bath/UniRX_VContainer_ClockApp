using System;
using UniRx;

namespace Timer
{
    public class TimerModel
    {
        private ReactiveProperty<bool> isRunning = new ReactiveProperty<bool>(true);
        private ReactiveProperty<float> elapsedTime = new ReactiveProperty<float>(0f);

        public IReadOnlyReactiveProperty<bool> IsRunning => isRunning;
        public IReactiveProperty<float> ElapsedTime => elapsedTime;

        public void ToggleTimer()
        {
            isRunning.Value = !isRunning.Value;
            UnityEngine.Debug.Log("isRunning.Value = " + isRunning.Value);
        }

        public void ResetTimer()
        {
            isRunning.Value = false;
            elapsedTime.Value = 0f;
        }
    }
}