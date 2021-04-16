using KyRator.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KyRator.Data.Repositories.Implementations
{
    public class KyRatorContext : DbContext
    {
        public DbSet<Sectant> Sectants { get; set; }

        public KyRatorContext(DbContextOptions<KyRatorContext> options) : base(options)
        {
        }

        public KyRatorContext()
        {
            Database.EnsureCreated();
        }
    }
}
