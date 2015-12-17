﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Repositories
{
    public interface IRepositoryBase<T> where T: class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T Find(Expression<Func<T, bool>> predicate);
        T GetById(int id);
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        IQueryable GetAll();
        void Commit();
    }
}
