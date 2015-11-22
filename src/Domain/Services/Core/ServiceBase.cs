using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts.Repositories;
using Domain.Contracts.Services.Core;

namespace Domain.Services.Core
{
    public class ServiceBase<T>: IServiceBase<T> where T: class
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

        public void Update(T entity)
        {
            _repositoryBase.Update(entity);
        }

        public T Get(int id)
        {
            return _repositoryBase.Get(id);
        }

        public IQueryable<T> Get()
        {
           return _repositoryBase.Get();
        }

        public void Commit()
        {
            _repositoryBase.Commit();
        }
    }
}
