using System;
using System.Diagnostics;
using UniRx;
using VContainer.Unity;

namespace Stopwatch
{
    //Responsible for Control Flow
    public class StopwatchViewModel : IStartable, ITickable
    {
        readonly StopwatchModel stopwatchModel;
        readonly StopwatchView stopwatchView;

        private CompositeDisposable disposables = new();

        public StopwatchViewModel(StopwatchModel stopwatchModel, StopwatchView stopwatchView)
        {
            this.stopwatchModel = stopwatchModel;
            this.stopwatchView = stopwatchView;
        }

        void IStartable.Start()
        {
            stopwatchView.StartPauseButton.OnClickAsObservable()
                .Subscribe(_ => stopwatchModel.ToggleStopwatch())
                .AddTo(stopwatchView);

            stopwatchView.ResetButton.OnClickAsObservable()
                .Subscribe(_ => 
                {
                    stopwatchModel.ResetStopwatch();
                    stopwatchView.ResetLaps();
                })
                .AddTo(stopwatchView);

            stopwatchView.LapButton.OnClickAsObservable()
                .Subscribe(_ => stopwatchModel.AddLapTime())
                .AddTo(stopwatchView);

            stopwatchModel.ElapsedTime
                .DistinctUntilChanged()
                .Where(time => time == 0.0f)
                .Subscribe(_ =>
                {
                    stopwatchView.InstantiateLapPrefabWithTime(stopwatchView.TimeToString(stopwatchModel.PreviousLap.Value));
                })
                .AddTo(stopwatchView);

            Observable.Interval(TimeSpan.FromMilliseconds(100))
                .TakeWhile(_ => stopwatchModel.IsRunning.Value == true)
                .Repeat()  // This allows pausing and not just stopping of the stopwatch
                .Subscribe(_ => stopwatchModel.ElapsedTime.Value += 100f)
                .AddTo(stopwatchView);
        }

        void ITickable.Tick()
        {
            Observable.EveryUpdate()
                .Subscribe(_ =>
                {
                    stopwatchView.UpdateUIElementText(stopwatchView.CurrentLap, stopwatchModel.ElapsedTime.Value);
                })
                .AddTo(disposables);
        }
    }
}