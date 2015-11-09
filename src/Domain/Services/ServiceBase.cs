using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts.Repositories;
using Domain.Contracts.Services;

namespace Domain.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        private readonly IRepositoryBase<T> _repositoryBase;

        public ServiceBase(IRepositoryBase<T> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public void Add(T entity)
        {
            _repositoryBase.Add(entity);
        }

        public void Delete(T entity)
        {
            _repositoryBase.Delete(entity);
        }

        public IQueryable<T> Get()
        {
            return Get();
        }

        public T Get(int id)
        {
            return Get(id);
        }

        public void Update(T entity)
        {
            _repositoryBase.Update(entity);
        }

        public void Commit()
        {
            _repositoryBase.Commit();
        }
    }
}
