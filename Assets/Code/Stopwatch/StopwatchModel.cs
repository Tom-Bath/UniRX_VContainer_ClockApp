using UniRx;

namespace Stopwatch
{
    public class StopwatchModel
    {
        private ReactiveProperty<bool> isRunning;
        private ReactiveProperty<float> elapsedTime;
        private ReactiveProperty<float> previousLap;

        public IReadOnlyReactiveProperty<bool> IsRunning => isRunning;
        public IReactiveProperty<float> ElapsedTime => elapsedTime;
        public IReadOnlyReactiveProperty<float> PreviousLap => previousLap;
        public StopwatchModel()
        {
            isRunning = new ReactiveProperty<bool>(false);
            elapsedTime = new ReactiveProperty<float>(1f); //TODO cant be 0
            previousLap = new ReactiveProperty<float>(0f);
        }
        public void ToggleStopwatch()
        {
            isRunning.Value = !isRunning.Value;
        }

        public void ResetStopwatch()
        {
            isRunning.Value = false;
            elapsedTime.Value = 0f;
        }

        public void AddLapTime()
        {
            previousLap.Value = elapsedTime.Value;
            elapsedTime.Value = 0f;
        }
    }
}