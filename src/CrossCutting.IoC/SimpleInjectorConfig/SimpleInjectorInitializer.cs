using System.Reflection;
using System.Web.Mvc;
using CrossCutting.IoC.Containers;
using SharedKernel.DomainEvents;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

namespace CrossCutting.IoC.SimpleInjectorConfig
{
    public static class SimpleInjectorInitializer
    {
        private static Container _container;

        public static void Initialize()
        {
            _container = new Container();
            _container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            InitializeContainer(_container);
            _container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            _container.RegisterMvcIntegratedFilterProvider();

            var dependencyResolver = new SimpleInjectorDependencyResolver(_container);
            DependencyResolver.SetResolver(dependencyResolver);
            DomainEvent.Container = new DomainEventContainer(dependencyResolver);

            _container.Verify();
        }

        private static void InitializeContainer(Container container)
        {
            BootStrapper.RegisterServices(container);
        }
    }
}
