using Domain.Contracts.Repositories;
using Infra.Data.Context;
using System.Data.Entity;
using System.Linq;

namespace Infra.Data.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T: class
    {
        protected AppDbContext _DbContext;

        public RepositoryBase()
        {
            _DbContext = new AppDbContext();
        }

        public void Add(T entity)
        {
            _DbContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _DbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _DbContext.Set<T>().Remove(entity);
        }

        public IQueryable Get()
        {
            return _DbContext.Set<T>();
        }

        public T Get(int id)
        {
            return _DbContext.Set<T>().Find(id);
        }

       
        public void Commit()
        {
            _DbContext.SaveChanges();
        }
    }
}
