using CrossCutting.IoC.SimpleInjectorConfig;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MVC5.Startup))]

namespace MVC5
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            SimpleInjectorInitializer.Initialize();
        }
    }
}
