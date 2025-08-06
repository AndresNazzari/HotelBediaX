using BediaX.Application.Destinations.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace BediaX.API.Extensions;

/// <summary>
/// Extension methods for registering API-related services.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers API services, including MediatR handlers and FluentValidation validators.
    /// </summary>
    /// <param name="services">The service collection to add services to.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        // MediatR: registers all handlers in the Application assembly
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Application.Destinations.Commands.CreateDestinationCommand>());

        // FluentValidation: registers all validators in the Application assembly
        services.AddValidatorsFromAssemblyContaining<CreateDestinationCommandValidator>();

        // Integrates FluentValidation with the ASP.NET Core model-state pipeline
        services.AddFluentValidationAutoValidation();

        return services;
    }
}