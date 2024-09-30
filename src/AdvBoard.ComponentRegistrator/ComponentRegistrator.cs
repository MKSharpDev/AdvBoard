using AdvBoard.AppServices.Contexts.Advertisement.Service;
using Microsoft.Extensions.DependencyInjection;

namespace AdvBoard.ComponentRegistrator
{
    public static class ComponentRegistrator
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAdvertisemenService, AdvertisemenService>();

            return services;
        }
    }
}
