using System;
using System.Collections.Generic;
using KyRator.Data.Entities;
using KyRator.Data.Repositories.Implementations;
using KyRator.Data.Repositories.Interfaces;

namespace KyRator.Data.Services
{
    public class SectantDataService : IDataService<Sectant>
    {
        private readonly IGenericRepository<Sectant> _repository;

        public SectantDataService(KyRatorContext context)
        {
            _repository = new GenericRepository<Sectant>(context, context.Sectants);
        }

        public Sectant Create(Sectant entity) => _repository.Create(entity);

        public Sectant FirstOrDefault(Func<Sectant, bool> predicate) => _repository.FirstOrDefault(predicate);

        public Sectant FindById(string id) => _repository.FindById(id);

        public IEnumerable<Sectant> GetAll() => _repository.GetAll();

        public IEnumerable<Sectant> Where(Func<Sectant, bool> predicate) => _repository.Where(predicate);

        public void Remove(Sectant entity)
        {
            _repository.Remove(entity);
        }

        public Sectant Update(Sectant entity) => _repository.Update(entity);
    }
}