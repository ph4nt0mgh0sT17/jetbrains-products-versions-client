using JetBrainsProductsVersionsClient.Services;
using JetBrainsProductsVersionsClient.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

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

    /// <summary>
    /// Adds Serilog Logger to <see cref="IServiceCollection"/> to be used in services.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" /> that contains all services, repositories and other objects.</param>
    /// <returns></returns>
    public static IServiceCollection AddLogger(this IServiceCollection services)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.File("JetBrainsProductsVersionsClient.log")
            .WriteTo.Console(LogEventLevel.Information)
            .CreateLogger();

        services.AddLogging(configure => configure.AddSerilog());

        return services;
    }
}