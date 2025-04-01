using Microsoft.Extensions.DependencyInjection;
using PerfTest.DataGen.Services;
using PerfTest.DataGen.Services.Impl;

namespace PerfTest.DataGen;

public static class ConfigureServices
{
    /// <summary>
    /// Adds and configures the necessary services for the ShoppingCarts Application.
    /// </summary>
    /// <param name="services">The service collection to which the services are added.</param>
    /// <returns>The updated <see cref="IServiceCollection"/> with the registered services.</returns>
    public static IServiceCollection AddDataGenServices(this IServiceCollection services)
    {
        services.AddSingleton<IOrderServiceDataGen, OrderServiceDataGen>();
        services.AddMemoryCache();
        return services;
    }
}
