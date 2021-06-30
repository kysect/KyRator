using KyRator.Data.Entities;
using KyRator.Data.Services;

namespace KyRator.Core.Managers
{
    public class SectantsManager
    {
        private readonly IDataService<Sectant> _sectantDataService;

        public SectantsManager(IDataService<Sectant> sectantDataService)
        {
            _sectantDataService = sectantDataService;
        }

        public Sectant GetOrCreateSectant(string sectantId)
        {
            Sectant sectant = _sectantDataService.FindById(sectantId);
            if (sectant is null)
            {
                sectant = new Sectant();
                sectant.DiscordId = sectantId;
                sectant.Points = 0;
                _sectantDataService.Create(sectant);
            }

            return sectant;
        }
    }
}