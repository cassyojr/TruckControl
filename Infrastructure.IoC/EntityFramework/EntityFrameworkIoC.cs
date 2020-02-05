using Infrastructure.Context;
using Infrastructure.DbConfig;
using Infrastructure.Interfaces.Context;
using Infrastructure.Interfaces.Repository;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC.EntityFramework
{
    public static class EntityFrameworkIoC
    {
        internal static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration configuration = null)
        {
            var dbSettings = ResolveConfiguration.GetConnectionSettings(configuration);
            var connStringsSection = dbSettings.GetSection("ConnectionStrings");
            var conn = dbSettings.GetConnectionString("ContextConnection");

            services.Configure<ConnectionStrings>(options => connStringsSection.Bind(options));
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(conn));

            services.AddScoped<IApplicationContext, ApplicationContext>();
            services.AddScoped(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddScoped<ITruckRepository, TruckRepository>();

            return services;
        }
    }
}
