using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AdvBoard.DbMigrators
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args).ConfigureServices((hostContext, services) =>
            {
                services.AddServices(hostContext.Configuration);
            }).Build();
            await MigrateAsync(host.Services);
        }

        private static async Task MigrateAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetService<MigrationDbContext>();
            await context!.Database.MigrateAsync();
        }
    }
}