using System;
using UniRx;

namespace Time
{
    public class TimeModel
    {
        // ReactiveProperty to represent the current time
        private readonly ReactiveProperty<DateTime> currentTime = new ReactiveProperty<DateTime>();

        // Expose the current time as an observable property
        public IReadOnlyReactiveProperty<DateTime> CurrentTime => currentTime;

        // Method to update the current time
        public void UpdateTime()
        {
            currentTime.Value = DateTime.Now;
        }
        public void PrintHelloWorld()
        {
            UnityEngine.Debug.Log("Hello World");
        }

    }

}