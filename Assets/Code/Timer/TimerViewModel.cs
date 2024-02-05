using System;
using Time;
using UniRx;
using VContainer.Unity;

namespace Timer
{
    //Responsible for Control Flow
    public class TimerViewModel : IStartable, ITickable
    {
        readonly TimerModel timerModel;
        readonly TimerView timerView;

        private CompositeDisposable disposables = new();

        public TimerViewModel(TimerModel timerModel, TimerView timerView)
        {
            this.timerModel = timerModel;
            this.timerView = timerView;
        }

        void IStartable.Start()
        {
            // Running Timer Buttons
            timerView.StartPauseButton.OnClickAsObservable()
                .Where(_ => timerModel.RemainingTime.Value != TimeSpan.Zero)
                .Subscribe(_ => timerModel.ToggleTimer())
                .AddTo(disposables);

            timerView.ResetButton.OnClickAsObservable()
                .Subscribe(_ => timerModel.ResetTimer())
                .AddTo(disposables);
            
            // Setup Timer Buttons
            timerView.InputClearButton.OnClickAsObservable()
                .Subscribe(_ => timerModel.ClearTimer())
                .AddTo(disposables);
            
            // Time Increment Buttons
            timerView.PlusOneSecondButton.OnClickAsObservable()
                .Subscribe(_ => timerModel.IncrememntTimer(1))
                .AddTo(disposables);
            timerView.PlusTenSecondButton.OnClickAsObservable()
                .Subscribe(_ => timerModel.IncrememntTimer(10))
                .AddTo(disposables);
            timerView.PlusOneMinuteButton.OnClickAsObservable()
                .Subscribe(_ => timerModel.IncrememntTimer(60))
                .AddTo(disposables);
            timerView.PlusTenMinuteButton.OnClickAsObservable()
                .Subscribe(_ => timerModel.IncrememntTimer(600))
                .AddTo(disposables);
            timerView.PlusOneHourButton.OnClickAsObservable()
                .Subscribe(_ => timerModel.IncrememntTimer(3600))
                .AddTo(disposables);

            timerModel.IsRunning.Subscribe(isActive =>
            {
                timerView.ToggleInputUI(isActive);
                timerView.PlaySound(isActive, timerModel.RemainingTime.Value);
            }).AddTo(disposables);

            timerModel.RemainingTime.Subscribe(time =>
            {
                timerView.UpdateUIRemainingTime(timerModel.RemainingTime.Value);

            }).AddTo(disposables);

            Observable.Interval(TimeSpan.FromMilliseconds(100))
                .TakeWhile(_ => timerModel.IsRunning.Value == true)
                .Repeat()  // This allows pausing and not just stopping of the timer
                .Subscribe(_ => timerModel.RemainingTime.Value -= TimeSpan.FromMilliseconds(100))
                .AddTo(disposables);
        }

        void ITickable.Tick()
        {
            Observable.EveryUpdate()
                .Subscribe(_ =>
                {
                    timerModel.CheckTimerIsZero();
                    timerView.UpdateUIRemainingTime(timerModel.RemainingTime.Value);
                })
                .AddTo(disposables);
        }
    }
}