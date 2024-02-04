using System;
using System.Collections.Generic;
using System.Diagnostics;
using UniRx;
using UnityEngine.UI;

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
            UnityEngine.Debug.Log("isRunning.Value = " + isRunning.Value);
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
                // Set your bool to false
                isRunning.Value = false;
            }
        }

        public void IncrememntTimer(int secondsToAdd)
        {
            UnityEngine.Debug.Log("Adding seconds" + secondsToAdd + ", remainintTime = " + remainingTime.Value);
 
            // 1 minute = 60 seconds, 10 minutes 600 seconds, 1 hour 3600 seconds
            remainingTime.Value = remainingTime.Value + TimeSpan.FromSeconds(secondsToAdd);

            UnityEngine.Debug.Log("Now remainintTime = " + remainingTime.Value);
        }
    }
}