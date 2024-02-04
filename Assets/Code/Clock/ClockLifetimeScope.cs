using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Clock
{
    public class ClockLifetimeScope : LifetimeScope
    {
        [SerializeField]
        ClockView clockView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<ClockModel>(Lifetime.Singleton);  
          
            builder.UseEntryPoints(Lifetime.Singleton, entryPoints =>
            {
                entryPoints.Add<ClockViewModel>();
            });

            builder.RegisterComponent(clockView);
        }
    }
}
