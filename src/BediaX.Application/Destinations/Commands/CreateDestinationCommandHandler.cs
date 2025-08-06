using BediaX.Application.Destinations.Interfaces;
using BediaX.Domain.Destinations.Entities;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace BediaX.Application.Destinations.Commands;

/// <summary>
/// Handles the <see cref="CreateDestinationCommand"/> to create a new destination.
/// </summary>
internal sealed class CreateDestinationCommandHandler : IRequestHandler<CreateDestinationCommand, int>
{
    private readonly IDestinationRepository _repository;
    private readonly IMemoryCache _cache;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateDestinationCommandHandler"/> class.
    /// </summary>
    /// <param name="repository">The repository used to persist the destination entity.</param>
    /// <param name="cache">The memory cache used to invalidate cached destination queries after creation.</param>
    public CreateDestinationCommandHandler(IDestinationRepository repository, IMemoryCache cache)
    {
        _repository = repository;
        _cache = cache;
    }

    /// <summary>
    /// Handles the command to create a new destination.
    /// </summary>
    /// <param name="command">The command containing destination details.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>The identifier of the newly created destination.</returns>
    public async Task<int> Handle(CreateDestinationCommand command, CancellationToken cancellationToken)
    {
        var destination = Destination.Create(
            command.Name,
            command.Description,
            command.CountryId,
            command.DestinationTypeId);

        await _repository.AddAsync(destination, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
        
        _cache.Remove(Shared.Constants.Cache.AllDestinationsCacheKey);
        
        return destination.Id;
    }
}