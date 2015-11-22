using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts.Repositories;
using Infra.Data.AppContext;

namespace Infra.Data.Repositories.Core
{
    public class RepositoryBase<T>: IRepositoryBase<T> where T: class
    {
        protected AppDbContext _db;

        public RepositoryBase()
        {
            _db = new AppDbContext();
        }

        #region Sync 
        public void Add(T entity)
        {
            _db.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
        }

        public T Get(int id)
        {
            return _db.Set<T>().Find(id);
        }

        public IQueryable<T> Get()
        {
           return _db.Set<T>();
        }

        public void Commit()
        {
            _db.SaveChanges();
        }

        #endregion


        #region Async
        
        #endregion
    }
}
