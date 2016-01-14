using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Services.Core
{
    public interface IDomainServiceBase<T> where T: class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T Find(int id);
        IQueryable<T> Get();
        IQueryable<T> GetAsNoTracking();
        void Save();
        void BeginTran();
        void Commit();
        void RollBack();

    }
}
