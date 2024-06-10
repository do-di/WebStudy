using Microsoft.Extensions.DependencyInjection;
using Domain.Interface.Storage;
using Infrastructure.Storage;
using Domain.Interface.Repository;
using Infrastructure.Repository;
using Domain.Interface.Cache;
using Infrastructure.Cache;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services)
        {
            services.AddSingleton<IAzureStorage, AzureStorage>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IRedisCache, RedisCache>();
            return services;
        }
    }
}