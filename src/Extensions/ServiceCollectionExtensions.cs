using Databases;
using Repositories;

namespace Extensions;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<DbHolder>();
        services.AddTransient<IShipRepository, ShipRepository>();

        return services;
    }
}