using System;
using KyRator.Data.Entities;
using KyRator.Data.Repositories.Implementations;
using KyRator.Data.Services.Implementations;
using KyRator.Data.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace KyRator
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<KyRatorContext>()
                .AddTransient<IDataService<Sectant>, SectantDataService>()
                .BuildServiceProvider();


        }
    }
}
