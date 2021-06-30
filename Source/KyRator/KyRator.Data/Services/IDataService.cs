using System;
using System.Collections.Generic;

namespace KyRator.Data.Services
{
    public interface IDataService<TEntity>
        where TEntity : class
    {
        TEntity Create(TEntity entity);
        TEntity FindById(string id);
        TEntity FirstOrDefault(Func<TEntity, bool> predicate);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Where(Func<TEntity, bool> predicate);
        void Remove(TEntity entity);
        TEntity Update(TEntity entity);
    }
}