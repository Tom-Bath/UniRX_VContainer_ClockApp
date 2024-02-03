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
            UnityEngine.Debug.Log("Starting Stopwatch");
            stopwatchView.StartPauseButton.OnClickAsObservable()
                .Subscribe(_ => stopwatchModel.ToggleStopwatch())
                .AddTo(stopwatchView);

            stopwatchView.ResetButton.OnClickAsObservable()
                .Subscribe(_ => stopwatchModel.ResetStopwatch())
                .AddTo(stopwatchView);

            stopwatchModel.IsRunning.Subscribe(isActive =>
            {
                stopwatchView.ToggleText(isActive);
                
            }).AddTo(stopwatchView);

            Observable.Interval(TimeSpan.FromMilliseconds(100))
                .TakeWhile(_ => stopwatchModel.IsRunning.Value == true)
                .Repeat()  // This allows pausing and not just stopping of the stopwatch
                .Subscribe(_ => stopwatchModel.ElapsedTime.Value += 100f)
                .AddTo(stopwatchView);
            UnityEngine.Debug.Log("Ending Stopwatch");
        }

        void ITickable.Tick()
        {
            Observable.EveryUpdate()
                .Subscribe(_ =>
                {
                    stopwatchView.UpdateUI(stopwatchModel.ElapsedTime.Value);
                })
                .AddTo(disposables);
        }
    }
}