using Application.Services;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.IoC.Services
{
    public static class ServicesIoC
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITruckService, TruckService>();
        }
    }
}
