using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Timer
{
    public class TimerLifetimeScope : LifetimeScope
    {
        [SerializeField]
        TimerView timerView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<TimerModel>(Lifetime.Singleton);  
          
            builder.UseEntryPoints(Lifetime.Singleton, entryPoints =>
            {
                entryPoints.Add<TimerViewModel>();
            });

            builder.RegisterComponent(timerView);
        }
    }
}
