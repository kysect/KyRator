using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KyRator.Data.Entities
{
    [Table("Sectants")]
    public class Sectant
    {
        [Key] public string DiscordId { get; set; }

        public string Nickname { get; set; }
        public string GithubProfile { get; set; }
        public int Points { get; set; }
    }
}