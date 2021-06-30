using System;
using System.Linq;
using KyRator.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KyRator.Data.Repositories.Implementations
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(DbContext context, DbSet<TEntity> set)
        {
            _context = context;
            _dbSet = set;
        }

        public IQueryable<TEntity> GetAll() => throw new NotImplementedException();

        public IQueryable<TEntity> Where(Func<TEntity, bool> predicate) => _dbSet.Where(predicate).AsQueryable();

        public TEntity FindById(string id) => _dbSet.Find(id);

        public TEntity FirstOrDefault(Func<TEntity, bool> predicate) => _dbSet.FirstOrDefault(predicate);

        public TEntity Create(TEntity item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
            return item;
        }

        public TEntity Update(TEntity item)
        {
            _dbSet.Update(item);
            _context.SaveChanges();
            return item;
        }

        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }

        public IQueryable<TEntity> Get() => _dbSet;
    }
}