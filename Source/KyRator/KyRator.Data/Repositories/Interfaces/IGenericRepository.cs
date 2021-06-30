using System;
using System.Linq;

namespace KyRator.Data.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity>
        where TEntity : class
    {
        TEntity Create(TEntity item);
        TEntity FindById(string id);
        TEntity FirstOrDefault(Func<TEntity, bool> predicate);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Where(Func<TEntity, bool> predicate);
        void Remove(TEntity item);
        TEntity Update(TEntity item);
    }
}