using System;
using UniRx;

namespace Time
{
    public class TimerModel
    {
        private ReactiveProperty<bool> isRunning = new ReactiveProperty<bool>(false);
        private ReactiveProperty<TimeSpan> remainingTime = new ReactiveProperty<TimeSpan>(TimeSpan.Zero);

        public IReadOnlyReactiveProperty<bool> IsRunning => isRunning;
        public IReactiveProperty<TimeSpan> RemainingTime => remainingTime;

        public void ToggleTimer()
        {
            isRunning.Value = !isRunning.Value;
        }

        public void ResetTimer()
        {
            isRunning.Value = false;
            ClearTimer();  //TODO revert to original time?
        }

        public void ClearTimer()
        {
            remainingTime.Value = TimeSpan.Zero;
        }
        
        public void CheckTimerIsZero()
        {
            if (remainingTime.Value <= TimeSpan.Zero)
            {
                isRunning.Value = false;
            }
        }

        public void IncrememntTimer(int secondsToAdd)
        {
            remainingTime.Value = remainingTime.Value + TimeSpan.FromSeconds(secondsToAdd);
        }
    }
}