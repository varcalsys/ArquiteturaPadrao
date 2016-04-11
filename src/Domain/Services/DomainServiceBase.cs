using System.Linq;
using Domain.Contracts.Repositories.Core;
using Domain.Contracts.Services.Core;
using Domain.Entities.Core;

namespace Domain.Services
{
    public abstract class DomainServiceBase<T> : IDomainServiceBase<T>  where T : EntityBase
    {
        private readonly IRepositoryBase<T> _repositoryBase;

        protected DomainServiceBase(IRepositoryBase<T> repositoryBase)
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

        public void Delete(T entity)
        {
            _repositoryBase.Delete(entity);
        }

        public void Save()
        {
            _repositoryBase.Save();
        }

        public void BeginTran()
        {
            _repositoryBase.BeginTran();
        }

        public void Commit()
        {
            _repositoryBase.Commit();
        }

        public void RollBack()
        {
            _repositoryBase.RollBack();
        }

        
    }
}
