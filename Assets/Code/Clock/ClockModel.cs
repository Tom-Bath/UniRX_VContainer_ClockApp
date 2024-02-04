using System;
using UniRx;

namespace Clock
{
    public class ClockModel
    {
        private readonly ReactiveProperty<DateTime> currentTime = new ReactiveProperty<DateTime>();
        public IReadOnlyReactiveProperty<DateTime> CurrentTime => currentTime;

        public void UpdateClock()
        {
            currentTime.Value = DateTime.Now;
        }
    }
}