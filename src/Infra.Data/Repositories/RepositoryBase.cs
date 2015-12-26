using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Domain.Contracts.Repositories.Core;
using Infra.Data.Context;

namespace Infra.Data.Repositories
{
    public abstract class RepositoryBase<T>: IRepositoryBase<T> where T: class
    {
        protected AppDbContext Db;

        protected RepositoryBase(AppDbContext db)
        {
            Db = db;
        }

       
        public void Add(T entity)
        {
            Db.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            Db.Set<T>().Remove(entity);
        }

        public T Find(int id)
        {
           return Db.Set<T>().Find(id);
        }

        public T Find(Expression<Func<T, bool>> predicate)
        {
            return Db.Set<T>().FirstOrDefault(predicate);
        }

        public IQueryable Get(Expression<Func<T, bool>> predicate)
        {
            return Db.Set<T>().Where(predicate);
        }

        public IQueryable Get()
        {
            return Db.Set<T>();
        }

        public IQueryable GetAsNoTracking(Expression<Func<T, bool>> predicate)
        {
            return Db.Set<T>().Where(predicate).AsNoTracking();
        }

        public IQueryable GetAsNoTracking()
        {
            return Db.Set<T>().AsNoTracking();
        }

        public void Commit()
        {
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
