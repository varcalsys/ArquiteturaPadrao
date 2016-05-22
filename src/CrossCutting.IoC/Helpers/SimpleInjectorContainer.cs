using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CrossCutting.IoC.SimpleInjectorConfig;
using SimpleInjector;

namespace CrossCutting.IoC.Helpers
{
    public class SimpleInjectorContainer: IDependencyResolver
    {

        protected Container Container;

        public SimpleInjectorContainer()
        {
            Container = SimpleInjectorInitializer.GetContainer();
        }

        public void Dispose()
        {
            Container.Dispose();
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return Container.GetInstance(serviceType);
            }
            catch (Exception)
            {

                return null;
            }

        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Container.GetAllInstances(serviceType);
        }
    }
}
