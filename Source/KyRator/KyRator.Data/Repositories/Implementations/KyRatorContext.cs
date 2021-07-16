using KyRator.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace KyRator.Data.Repositories.Implementations
{
    public class KyRatorContext : DbContext
    {
        public DbSet<Sectant> Sectants { get; set; }
        public DbSet<Suggestion> Suggestions { get; set; }

        public KyRatorContext(DbContextOptions<KyRatorContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public KyRatorContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=kybase.db");
        }
    }
}