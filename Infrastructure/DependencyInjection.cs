using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Domain.Interface.Storage;
using Infrastructure.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services)
        {
            services.AddSingleton<IAzureStorage, AzureStorage>();
            services.AddDbContext<ApplicationDbContext>(options => options.UseCosmos(
                "https://dodi.documents.azure.com:443",
                "5BpjEwA0J760MC2eVuW9Gt6gvALuxcP5J3RMvRQHPxKUB8JrHHLldiqpkBfFrvan6iEX2x5tRceeACDb1fk7Yw==",
                databaseName: "DoDiCosmos")
            );
            return services;
        }
    }
}