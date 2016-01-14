﻿using System.Linq;
using Domain.Contracts.Repositories.Core;
using Domain.Contracts.Services.Core;

namespace Domain.Services
{
    public abstract class DomainServiceBase<T> : IDomainServiceBase<T>  where T : class
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

        public T Find(int id)
        {
            return _repositoryBase.Find(id);
        }

        public IQueryable<T> Get()
        {
            return _repositoryBase.Get();
        }

        public IQueryable<T> GetAsNoTracking()
        {
            return _repositoryBase.GetAsNoTracking();
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
