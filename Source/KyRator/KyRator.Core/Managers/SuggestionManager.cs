using KyRator.Data.Entities;
using KyRator.Data.Services;

namespace KyRator.Core.Managers
{
    public class SuggestionManager
    { 
        private readonly IDataService<Suggestion> _suggestionDataService;

        public SuggestionManager(IDataService<Suggestion> suggestionDataService)
        {
            _suggestionDataService = suggestionDataService;   
        }

        public Suggestion CreateSuggestion(Sectant sectant, int amount, string description)
        {
            var suggestion = new Suggestion();
            suggestion.Sectant = sectant;
            suggestion.Amount = amount;
            suggestion.Description = description;
            _suggestionDataService.Create(suggestion);
            return suggestion;
        }
    }
}