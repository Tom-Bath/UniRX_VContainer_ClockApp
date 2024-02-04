using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Stopwatch
{
    public class StopwatchLifetimeScope : LifetimeScope
    {
        [SerializeField]
        StopwatchView stopwatchView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<StopwatchModel>(Lifetime.Singleton);  
          
            builder.UseEntryPoints(Lifetime.Singleton, entryPoints =>
            {
                entryPoints.Add<StopwatchViewModel>();
            });

            builder.RegisterComponent(stopwatchView);
        }
    }
}
