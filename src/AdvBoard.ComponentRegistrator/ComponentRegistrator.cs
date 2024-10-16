using AdvBoard.AppServices.Contexts.Advertisement.Repository;
using AdvBoard.AppServices.Contexts.Advertisement.Service;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using AdvBoard.DataAccess.Repository;
using AdvBoard.Infrastructure.Repository;
using AdvBoard.MapProfile;
using AdvBoard.AppServices.Contexts.Category.Service;
using AdvBoard.AppServices.Contexts.Category.Repository;
using AdvBoard.AppServices.Helpers;

namespace AdvBoard.ComponentRegistrator
{
    public static class ComponentRegistrator
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IMapper>(new Mapper(GetMapperConfiguration()));

            services.AddScoped<IAdvertisemenService, AdvertisemenService>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddScoped<IAdvertisemenRepository, AdvertisementRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<IJwtProvider, JwtProvider>();

            

            return services;
        }

        private static MapperConfiguration GetMapperConfiguration()
        {
            var configuration = new MapperConfiguration(cfg =>
            {              
                cfg.AddProfile<AdvertProfile>();
                cfg.AddProfile<CategoryProfile>();
            });
            configuration.AssertConfigurationIsValid();
            return configuration;
        }
    }
}
