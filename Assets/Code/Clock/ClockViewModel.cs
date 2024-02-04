using System.Diagnostics;
using UniRx;
using VContainer.Unity;

namespace Clock
{
    //Responsible for Control Flow
    public class ClockViewModel : IStartable, ITickable
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
            clockView.clockButton.OnClickAsObservable()
                .Subscribe(_ => clockModel.PrintHelloWorld())
                .AddTo(disposables);
        }

        void ITickable.Tick()
        {
            Observable.EveryUpdate()
                .Subscribe(_ => clockModel.UpdateClock())
                .AddTo(disposables);

            Observable.EveryUpdate()
                .Subscribe(_ => UpdateTimeInView())
                .AddTo(disposables);
        }

        private void UpdateTimeInView()
        {
            clockView.UpdateUI(clockModel.CurrentTime.Value);
        }
    }
}