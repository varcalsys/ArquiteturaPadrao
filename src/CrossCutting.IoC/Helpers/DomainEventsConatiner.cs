using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using SharedKernel;

namespace CrossCutting.IoC.Helpers
{
    public class DomainEventsConatiner: IContainer
    {
        private readonly IDependencyResolver _resolver;

        public DomainEventsConatiner(IDependencyResolver resolver)
        {
            _resolver = resolver;
        }

        public object GetService(Type serviceType)
        {
            return _resolver.GetService(serviceType);
        }

        public T GetService<T>()
        {
            return (T)_resolver.GetService(typeof(T));
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _resolver.GetServices(serviceType);
        }

        public IEnumerable<T> GetServices<T>()
        {
            return (IEnumerable<T>)_resolver.GetServices(typeof(T));
        }
    }
}
