using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using KyRator.Data.Entities;
using KyRator.Data.Services.Interfaces;

namespace KyRator.Core
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
            if (points <= 0) throw new ArgumentOutOfRangeException(nameof(points));

            var sectant = _sectantDataService.Get().FirstOrDefault(el => el.DiscordId == discordId);
            if (sectant == null) throw new InvalidOperationException();

            sectant.Points += points;
            _sectantDataService.Update(sectant);
        }

        public void SendPoints(string discordIdFrom, string discordIdTo, int amount)
        {
            if (discordIdFrom == null) throw new ArgumentNullException(nameof(discordIdFrom));
            if (discordIdTo == null) throw new ArgumentNullException(nameof(discordIdTo));
            if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount));

            var sectantFrom = _sectantDataService.Get().FirstOrDefault(el => el.DiscordId == discordIdFrom);
            var sectantTo = _sectantDataService.Get().FirstOrDefault(el => el.DiscordId == discordIdTo);

            if (sectantFrom == null) throw new InvalidOperationException();
            if (sectantTo == null) throw new InvalidOperationException();

            //ToDo make transaction
            sectantFrom.Points -= amount;
            sectantTo.Points += amount;
        }

        public int GetPoints(string discordId)
        {
            if (discordId == null) throw new ArgumentNullException(nameof(discordId));

            var sectant = _sectantDataService.Get().FirstOrDefault(el => el.DiscordId == discordId);
            if (sectant == null) throw new InvalidOperationException();

            return sectant.Points;
        }
    }
}
