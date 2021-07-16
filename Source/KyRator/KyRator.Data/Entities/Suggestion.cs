using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KyRator.Data.Entities
{
    [Table("Suggestions")]
    public class Suggestion
    {
        [Key] public long Id { get; set; }
        public Sectant Sectant { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
    }
}