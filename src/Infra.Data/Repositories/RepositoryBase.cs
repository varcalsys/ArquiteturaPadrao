using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Domain.Contracts.Repositories.Core;
using Domain.Entities.Core;
using Infra.Data.Context;

namespace Infra.Data.Repositories
{
    public abstract class RepositoryBase<T>: IRepositoryBase<T> where T: EntityBase
    {
        protected AppDbContext Db;
        private DbContextTransaction _transaction;
        private bool _disposed;


        protected RepositoryBase(AppDbContext db)
        {
            Db = db;
        }

       
        public virtual void Add(T entity)
        {
            Db.Set<T>().Add(entity);
        }
        public virtual void Update(T entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            Db.Set<T>().Remove(entity);
        }


        public virtual T GetById(int id, params Expression<Func<T, object>>[] includes)
        {
            var query = Db.Set<T>().AsQueryable();

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return query.SingleOrDefault(x=>x.Id == id);
        }
        public virtual IQueryable<T> Get(Expression<Func<T, bool>> predicate, params Expression<Func<T,object>>[] includes)
        {
            var query = Db.Set<T>().AsQueryable();

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return query.Where(predicate);
        }
        public virtual IQueryable<T> GetAsNoTracking(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            return Get(predicate, includes).AsNoTracking();
        }
        public virtual IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            var query = Db.Set<T>().AsQueryable();

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return query;
        }
        public virtual IQueryable<T> GetAllAsNoTracking(params Expression<Func<T, object>>[] includes)
        {
            return GetAll().AsNoTracking();
        }


        public virtual void Save()
        {
            Db.SaveChanges();
        }
        public virtual void BeginTran()
        {
            _transaction = Db.Database.BeginTransaction();
        }
        public virtual void Commit()
        {
            _transaction.Commit();
        }
        public virtual void RollBack()
        {
            _transaction.Rollback();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Db?.Dispose();
                }

                _disposed = true;
            }                         
        }
    }
}
