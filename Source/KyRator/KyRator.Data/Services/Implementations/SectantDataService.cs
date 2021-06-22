using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KyRator.Data.Entities;
using KyRator.Data.Repositories.Implementations;
using KyRator.Data.Repositories.Interfaces;
using KyRator.Data.Services.Interfaces;

namespace KyRator.Data.Services.Implementations
{
    public class SectantDataService : IDataService<Sectant>
    {
        private readonly IGenericRepository<Sectant> _repository;
        public SectantDataService(KyRatorContext context)
        {
            _repository = new GenericRepository<Sectant>(context, context.Sectants);
        }
        public Sectant Create(Sectant entity)
        {
            return _repository.Create(entity);
        }
        public Sectant FindById(Guid id)
        {
            return _repository.FindById(id);
        }
        public IEnumerable<Sectant> Get()
        {
            return _repository.Get();
        }
        public IEnumerable<Sectant> Where(Func<Sectant, bool> predicate)
        {
            return _repository.Where(predicate);
        }
        public void Remove(Sectant entity)
        {
            _repository.Remove(entity);
        }
        public Sectant Update(Sectant entity)
        {
            return _repository.Update(entity);
        }
    }
}
