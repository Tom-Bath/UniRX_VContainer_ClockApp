using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Clock
{
    public class ClockLifetimeScope : LifetimeScope
    {
        [SerializeField]
        ClockScreen clockScreen;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<ClockService>(Lifetime.Singleton);  
          
            builder.UseEntryPoints(Lifetime.Singleton, entryPoints =>
            {
                entryPoints.Add<ClockPresenter>();
                // Add addional as needed
            });

            builder.RegisterComponent(clockScreen);
        }
    }
}
