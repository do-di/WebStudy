using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Domain.Interface.Storage;
using Infrastructure.Storage;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services)
        {
            services.AddSingleton<IAzureStorage, AzureStorage>();
            return services;
        }
    }
}