using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KyRator.Data.Entities
{
    public class Sectant
    {
        public Guid Id { get; set; }
        public string Nickname { get; set; }
        public string FullName { get; set; }
        public string GitHubProfile { get; set; }
        public string DiscordProfile { get; set; }
        public int Points { get; set; }
    }
}
