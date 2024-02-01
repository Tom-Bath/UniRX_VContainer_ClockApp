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

            // Add/Register new stuff as needed, otherwise you will get this error
            // VContainerException: Failed to resolve Clock.XYZ : No such registration of type: Clock.XYZ
        }
    }
}
