using BediaX.Application.Catalog.Interfaces;
using BediaX.Application.Destinations.Interfaces;
using BediaX.Infrastructure.Catalog.Repositories;
using BediaX.Infrastructure.Destinations.Data;
using BediaX.Infrastructure.Destinations.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BediaX.Infrastructure.Extensions;

/// <summary>
/// Extension methods for registering infrastructure layer services.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers infrastructure services, including the database context and repositories.
    /// </summary>
    /// <param name="services">The service collection to add the services to.</param>
    /// <param name="configuration">The application configuration.</param>
    /// <returns>The updated <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connection = configuration.GetConnectionString("Default") ?? "Data Source=./data/bediax.db";

        // DbContext
        services.AddDbContext<BediaXDbContext>(opt => opt.UseSqlite(connection));

        // Repositories
        services.AddScoped<IDestinationRepository, DestinationRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IDestinationTypeRepository, DestinationTypeRepository>();
        
        return services;
    }
}