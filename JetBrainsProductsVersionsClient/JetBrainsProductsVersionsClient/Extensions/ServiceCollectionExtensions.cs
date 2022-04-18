using JetBrainsProductsVersionsClient.Services;
using JetBrainsProductsVersionsClient.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace JetBrainsProductsVersionsClient.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    ///     Adds all services into Dependency Injection Service Collection for use in the application.
    /// </summary>
    /// <param name="services">
    ///     The <see cref="IServiceCollection" /> that contains all services, repositories and other
    ///     objects.
    /// </param>
    public static IServiceCollection AddAllServices(this IServiceCollection services)
    {
        services.AddSingleton<IJetBrainsApiService, JetBrainsApiService>();
        return services;
    }

    /// <summary>
    ///     Adds all repositories into Dependency Injection Service Collection for use in the application.
    /// </summary>
    /// <param name="services">
    ///     The <see cref="IServiceCollection" /> that contains all services, repositories and other
    ///     objects.
    /// </param>
    public static IServiceCollection AddAllRepositories(this IServiceCollection services)
    {
        return services;
    }

    /// <summary>
    ///     Adds all View Models into Dependency Injection Service Collection for use in the application.
    /// </summary>
    /// <param name="services">
    ///     The <see cref="IServiceCollection" /> that contains all services, repositories and other
    ///     objects.
    /// </param>
    public static IServiceCollection AddAllViewModels(this IServiceCollection services)
    {
        services.AddTransient<ProductsDashboardViewModel>();
        return services;
    }
}