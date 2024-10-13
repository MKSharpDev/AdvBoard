using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvBoard.DbMigrators
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureDbConnection(configuration);
            return services;
        }

        private static IServiceCollection ConfigureDbConnection(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            services.AddDbContext<MigrationDbContext>(options => options.UseNpgsql(connectionString));
            return services;
        }
    }
}
