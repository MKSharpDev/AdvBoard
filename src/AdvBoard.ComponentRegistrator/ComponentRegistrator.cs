using AdvBoard.AppServices.Contexts.Advertisement.Repository;
using AdvBoard.AppServices.Contexts.Advertisement.Service;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using AdvBoard.DataAccess.Repository;
using AdvBoard.Infrastructure.Repository;
using AdvBoard.MapProfile;

namespace AdvBoard.ComponentRegistrator
{
    public static class ComponentRegistrator
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IMapper>(new Mapper(GetMapperConfiguration()));

            services.AddScoped<IAdvertisemenService, AdvertisemenService>();

            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddScoped<IAdvertisemenRepository, AdvertisementRepository>();



            return services;
        }

        private static MapperConfiguration GetMapperConfiguration()
        {
            var configuration = new MapperConfiguration(cfg =>
            {              
                cfg.AddProfile<AdvertProfile>();         
            });
            configuration.AssertConfigurationIsValid();
            return configuration;
        }
    }
}
