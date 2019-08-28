using Credit.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Credit.Core.Data
{
    public interface IBaseEntityRepository<T> where T : class, IBaseEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter = null);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}
