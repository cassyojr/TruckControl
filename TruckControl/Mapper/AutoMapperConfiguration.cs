using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace TruckControl.Mapper
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DomainViewModelProfile());
                mc.AddProfile(new ViewModelDomainProfile());
            });

            var mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }
    }
}
