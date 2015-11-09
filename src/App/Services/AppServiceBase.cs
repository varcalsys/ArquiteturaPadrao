using App.Contracts;
using Domain.Contracts.Services;
using System.Linq;

namespace App.Services
{
    public class AppServiceBase<T> : IAppServiceBase<T> where T: class 
    {

        private readonly IServiceBase<T> _serviceBase;

        public AppServiceBase(IServiceBase<T> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public void Registrar(T entity)
        {
            _serviceBase.Add(entity);
        }

        public void Alterar(T entity)
        {
            _serviceBase.Update(entity);
        }

        public T BuscarPorId(int id)
        {
            return _serviceBase.Get(id);
        }

        public IQueryable<T> BuscarTodos()
        {
            return _serviceBase.Get();
        }
        
    }
}
