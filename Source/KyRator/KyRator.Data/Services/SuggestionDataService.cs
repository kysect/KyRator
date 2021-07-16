using System;
using System.Collections.Generic;
using KyRator.Data.Entities;
using KyRator.Data.Repositories.Implementations;

namespace KyRator.Data.Services
{
    public class SuggestionDataService : IDataService<Suggestion>
    {
        private readonly GenericRepository<Suggestion> _repository;

        public SuggestionDataService(KyRatorContext context)
        {
            _repository = new GenericRepository<Suggestion>(context, context.Suggestions);
        }

        public Suggestion Create(Suggestion entity) => _repository.Create(entity);

        public Suggestion FindById(string id) => _repository.FindById(id);

        public Suggestion FirstOrDefault(Func<Suggestion, bool> predicate) => _repository.FirstOrDefault(predicate);

        public IEnumerable<Suggestion> GetAll() => _repository.GetAll();

        public IEnumerable<Suggestion> Where(Func<Suggestion, bool> predicate) => _repository.Where(predicate);

        public void Remove(Suggestion entity)
        {
            _repository.Remove(entity);
        }

        public Suggestion Update(Suggestion entity) => _repository.Update(entity);
    }
}