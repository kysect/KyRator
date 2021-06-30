using System;
using KyRator.Data.Entities;
using KyRator.Data.Services;

namespace KyRator.Core.Managers
{
    public class PointsManager
    {
        private readonly IDataService<Sectant> _sectantDataService;

        public PointsManager(IDataService<Sectant> sectantDataService)
        {
            _sectantDataService = sectantDataService;
        }

        public void GivePoints(string discordId, int points)
        {
            Sectant sectant = _sectantDataService.FirstOrDefault(el => el.DiscordId == discordId);
            if (sectant == null)
            {
                throw new InvalidOperationException();
            }

            sectant.Points += points;
            _sectantDataService.Update(sectant);
        }

        public void SendPoints(Sectant sectantFrom, Sectant sectantTo, int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }

            if (sectantFrom == null)
            {
                throw new InvalidOperationException();
            }

            if (sectantTo == null)
            {
                throw new InvalidOperationException();
            }

            if (sectantFrom.Points < amount)
            {
                throw new InvalidOperationException("Not enough points");
            }

            //TODO: make transaction
            sectantFrom.Points -= amount;
            sectantTo.Points += amount;
        }

        public int GetPoints(string discordId)
        {
            if (discordId == null)
            {
                throw new ArgumentNullException(nameof(discordId));
            }

            Sectant sectant = _sectantDataService.FirstOrDefault(el => el.DiscordId == discordId);
            if (sectant == null)
            {
                throw new InvalidOperationException();
            }

            return sectant.Points;
        }
    }
}