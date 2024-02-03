using System;
using UniRx;
using VContainer.Unity;

namespace Timer
{
    //Responsible for Control Flow
    public class TimerViewModel : IStartable, ITickable
    {
        readonly TimerModel timerModel;
        readonly TimerView timerView;

        private CompositeDisposable disposables;

        public TimerViewModel(TimerModel timerModel, TimerView timerView)
        {
            this.timerModel = timerModel;
            this.timerView = timerView;
        }

        void IStartable.Start()
        {
            timerView.StartPauseButton.OnClickAsObservable()
                .Subscribe(_ => timerModel.ToggleTimer())
                .AddTo(timerView);

            timerView.ResetButton.OnClickAsObservable()
                .Subscribe(_ => timerModel.ResetTimer())
                .AddTo(timerView);

            timerModel.IsRunning.Subscribe(isActive =>
            {
                timerView.ToggleText(isActive);
                
            }).AddTo(timerView);

            Observable.Interval(TimeSpan.FromMilliseconds(100))
                .TakeWhile(_ => timerModel.IsRunning.Value == true)
                .Repeat()  // This allows pausing and not just stopping of the timer
                .Subscribe(_ => timerModel.ElapsedTime.Value += 100f)
                .AddTo(timerView);

        }

        void ITickable.Tick()
        {
            Observable.EveryUpdate()
                .Subscribe(_ =>
                {
                    timerView.UpdateUI(timerModel.ElapsedTime.Value);
                })
                .AddTo(timerView); // AddTo to handle subscriptions lifecycle
        }
    }
}