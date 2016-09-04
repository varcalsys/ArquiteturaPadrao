using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using IContainer = SharedKernel.DomainEvents.Contracts.IContainer;

namespace CrossCutting.IoC.Containers
{
    public class DomainEventContainer: IContainer
    {
        private readonly IDependencyResolver _resolver;

        public DomainEventContainer(IDependencyResolver resolver)
        {
            _resolver = resolver;
        }

        public T GetService<T>()
        {
            return (T)_resolver.GetService(typeof(T));
        }

        public object GetService(Type serviceType)
        {
            return _resolver.GetService(serviceType);
        }

        public IEnumerable<T> GetServices<T>()
        {
            return (IEnumerable<T>)_resolver.GetServices(typeof(T));
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _resolver.GetServices(serviceType);
        }
    }
}
