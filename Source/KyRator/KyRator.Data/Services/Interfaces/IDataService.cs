using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KyRator.Data.Services.Interfaces
{
    public interface IDataService<TEntity>
        where TEntity : class
    {
        TEntity Create(TEntity entity);
        TEntity FindById(Guid id);
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        void Remove(TEntity entity);
        TEntity Update(TEntity entity);
    }
}
