using System;
using UniRx;

namespace Clock
{
    public class ClockModel
    {
        // ReactiveProperty to represent the current clock
        private readonly ReactiveProperty<DateTime> currentTime = new ReactiveProperty<DateTime>();

        // Expose the current clock as an observable property
        public IReadOnlyReactiveProperty<DateTime> CurrentTime => currentTime;

        // Method to update the current clock
        public void UpdateClock()
        {
            currentTime.Value = DateTime.Now;
        }
        public void PrintHelloWorld()
        {
            UnityEngine.Debug.Log("Hello World");
        }

    }

}