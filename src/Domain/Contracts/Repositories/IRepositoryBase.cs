using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Repositories
{
    public interface IRepositoryBase<T> where T: class
    {
        #region Sync

        void Add(T entity);
        void Update(T entity);
        T Get(int id);
        IQueryable<T> Get();

        void Commit();

        #endregion

        #region Async


        #endregion


    }
}
