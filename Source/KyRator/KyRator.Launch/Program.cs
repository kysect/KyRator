using System.Threading.Tasks;
using KyRator.BotCommands;
using KyRator.Data.Entities;
using KyRator.Data.Repositories.Implementations;
using KyRator.Data.Services;
using KyRator.Core.Managers;
using Kysect.BotFramework.ApiProviders.Discord;
using Kysect.BotFramework.Core;
using Kysect.BotFramework.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace KyRator.Core
{
    class Program
    {
        static void Main(string[] args) => MainAsync().GetAwaiter().GetResult();

        private static async Task MainAsync()
        {
            var token = "";
            ConstSettingsProvider<DiscordSettings> settings =
                new ConstSettingsProvider<DiscordSettings>(new DiscordSettings(token));
            var api = new DiscordApiProvider(settings);

            BotManagerBuilder botManagerBuilder = new BotManagerBuilder().SetPrefix('!').SetCaseSensitive(false)
                                                                         .AddCommand(TipCommand.Descriptor);

            botManagerBuilder.ServiceCollection.AddEntityFrameworkSqlite().AddDbContext<KyRatorContext>()
                             .AddTransient<IDataService<Sectant>, SectantDataService>().AddSingleton<SectantsManager>()
                             .AddSingleton<PointsManager>();
            BotManager botManager = botManagerBuilder.Build(api);

            botManager.Start();
            await Task.Delay(-1);
        }
    }
}