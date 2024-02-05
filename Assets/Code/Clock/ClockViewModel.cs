using System;
using UniRx;
using VContainer.Unity;

namespace Clock
{
    //Responsible for Control Flow
    public class ClockViewModel : ITickable, IStartable
    {
        readonly ClockModel clockModel;
        readonly ClockView clockView;

        private CompositeDisposable disposables = new();

        public ClockViewModel(ClockModel clockModel, ClockView clockView)
        {
            this.clockModel = clockModel;
            this.clockView = clockView;
        }

        void IStartable.Start()
        {
            Observable.Start(() =>
            {
                clockView.UpdateTimezoneUI(System.TimeZoneInfo.Local);
            })
            .Subscribe()
            .AddTo(disposables);
        }
        void ITickable.Tick()
        {
            Observable.EveryUpdate()
                .Subscribe(_ => clockModel.UpdateClock(DateTime.Now))
                .AddTo(disposables);

            Observable.EveryUpdate()
                .Subscribe(_ => UpdateTimeInView())
                .AddTo(disposables);
        }

        public void UpdateTimeInView()
        {
            clockView.UpdateClockUI(clockModel.CurrentTime.Value);
        }
    }
}