using UniRx;
using VContainer.Unity;

namespace Time
{
    //Responsible for Control Flow
    public class TimeViewModel : IStartable, ITickable
    {
        readonly TimeModel timeModel;
        readonly TimeView timeView;  

        public TimeViewModel(TimeModel timeModel, TimeView timeView)
        {
            this.timeModel = timeModel;
            this.timeView = timeView;
        }

        void IStartable.Start()
        {
            timeView.timeButton.OnClickAsObservable()
                .Subscribe(_ => timeModel.PrintHelloWorld())
                .AddTo(timeView);
        }

        void ITickable.Tick()
        {
            Observable.EveryUpdate()
                .Subscribe(_ => timeModel.UpdateTime())
                .AddTo(timeView); // AddTo to handle subscriptions lifecycle

            Observable.EveryUpdate()
                .Subscribe(_ => UpdateTimeInView())
                .AddTo(timeView); // AddTo to handle subscriptions lifecycle
        }

        private void UpdateTimeInView()
        {
            // Update your UI here using timeView or any other method you have in your timeView class
            timeView.UpdateUI(timeModel.CurrentTime.Value);
        }
    }
}