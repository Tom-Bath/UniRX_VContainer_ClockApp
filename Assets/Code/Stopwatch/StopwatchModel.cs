using System;
using UniRx;

namespace Stopwatch
{
    public class StopwatchModel
    {
        private ReactiveProperty<bool> isRunning = new ReactiveProperty<bool>(false);
        private ReactiveProperty<float> elapsedTime = new ReactiveProperty<float>(0f);

        public IReadOnlyReactiveProperty<bool> IsRunning => isRunning;
        public IReactiveProperty<float> ElapsedTime => elapsedTime;

        public void ToggleStopwatch()
        {
            isRunning.Value = !isRunning.Value;
        }

        public void ResetStopwatch()
        {
            isRunning.Value = false;
            elapsedTime.Value = 0f;
        }
    }
}