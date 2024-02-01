using VContainer.Unity;
using UniRx;

namespace Clock
{
    // Responsible only for Control Flow
    public class ClockPresenter : IStartable, ITickable
    {
        readonly ClockService clockService;
        readonly ClockScreen clockScreen;  

        public ClockPresenter(ClockService clockService, ClockScreen clockScreen)
        {
            this.clockService = clockService;
            this.clockScreen = clockScreen;
        }

        void ITickable.Tick()
        {
            // Subscribe to update event to continuously display current time
            Observable.EveryUpdate()
                .Subscribe(_ => clockService.UpdateClockUI(clockScreen.TimeText))
                .AddTo(clockScreen); // AddTo to handle subscriptions lifecycle

            // Could make the timer update per second using
            // Observable.Interval(System.TimeSpan.FromSeconds(1))
        }

        void IStartable.Start()
        {
            // Reactive version
            // Use UniRx to subscribe to the OnClick event of the button
            clockScreen.ClockButton.OnClickAsObservable()
                .Subscribe(_ => clockService.PrintHelloWorld())
                .AddTo(clockScreen);
        }
    }
}