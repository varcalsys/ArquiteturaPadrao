using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Repositories.Core
{
    public interface IRepositoryBase<T>: IDisposable where T: class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T Find(int id);
        T Find(Expression<Func<T, bool>> predicate);
        IQueryable Get(Expression<Func<T, bool>> predicate);
        IQueryable Get();
        IQueryable GetAsNoTracking(Expression<Func<T, bool>> predicate);
        IQueryable GetAsNoTracking();

        void Commit();

        #region Async Methods

        //void AddAsync(T entity);
        //void UpdateAsync(T entity);
        //void DeleteAsync(T entity);
        //T FindAsync(int id);

        #endregion
    }
}
