using System;
using System.Linq;
using System.Linq.Expressions;
using Domain.Entities.Core;

namespace Domain.Contracts.Repositories.Core
{
    public interface IRepositoryBase<T>: IDisposable where T: EntityBase
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(int id, params Expression<Func<T, object>>[] includes);
        IQueryable<T> Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes );
        IQueryable<T> GetAsNoTracking(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        IQueryable<T> GetAll(params Expression<Func<T,object>>[] includes);
        IQueryable<T> GetAllAsNoTracking(params Expression<Func<T, object>>[] includes);
        void Save();
        void BeginTran();
        void Commit();
        void RollBack();


        #region Async Methods

        

        #endregion
    }
}
