using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Display
{
    public class DisplayLifetimeScope : LifetimeScope
    {
        [SerializeField]
        DisplayView displayView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<DisplayModel>(Lifetime.Singleton);  
          
            builder.UseEntryPoints(Lifetime.Singleton, entryPoints =>
            {
                entryPoints.Add<DisplayViewModel>();
            });

            builder.RegisterComponent(displayView);
        }
    }
}
