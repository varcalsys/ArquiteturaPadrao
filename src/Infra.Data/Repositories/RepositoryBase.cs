using System;
using Domain.Contracts.Repositories;
using Infra.Data.Context;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Infra.Data.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T: class
    {
        protected readonly AppDbContext DbContext;

        public RepositoryBase(AppDbContext dbContext)
        {
            this.DbContext = dbContext;
        }    

        public void Add(T entity)
        {
            DbContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            DbContext.Set<T>().Remove(entity);
        }

        public T Find(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Set<T>().FirstOrDefault(predicate);
        }

        public T GetById(int id)
        {
            return DbContext.Set<T>().Find(id);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Set<T>().Where(predicate);
        }

        public IQueryable GetAll()
        {
            return DbContext.Set<T>();
        }     

        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}
