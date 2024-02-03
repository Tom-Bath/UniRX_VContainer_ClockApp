using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Time
{
    public class TimeLifetimeScope : LifetimeScope
    {
        [SerializeField]
        TimeView timeView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<TimeModel>(Lifetime.Singleton);  
          
            builder.UseEntryPoints(Lifetime.Singleton, entryPoints =>
            {
                entryPoints.Add<TimeViewModel>();
            });

            builder.RegisterComponent(timeView);
        }
    }
}
