using Domain.Interface.Repository;
using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services)
        {
            //services.AddSingleton<IAzureStorage, AzureStorage>();
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddSingleton<IRedisCache, RedisCache>();
            services.AddScoped<IStaticUserRepository, StaticUserRepository>();
            return services;
        }
    }
}