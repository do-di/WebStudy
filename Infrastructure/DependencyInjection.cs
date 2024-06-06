using Microsoft.Extensions.DependencyInjection;
using Domain.Interface.Storage;
using Infrastructure.Storage;
using Microsoft.EntityFrameworkCore;
using Domain.Interface.Repository;
using Infrastructure.Repository;

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
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}