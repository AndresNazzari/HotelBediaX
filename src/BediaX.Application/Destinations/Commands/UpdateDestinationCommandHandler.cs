using BediaX.Application.Destinations.Interfaces;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace BediaX.Application.Destinations.Commands;

/// <summary>
/// Handles the <see cref="UpdateDestinationCommand"/> to update an existing destination.
/// </summary>
internal sealed class UpdateDestinationCommandHandler : IRequestHandler<UpdateDestinationCommand, bool>
{
    private readonly IDestinationRepository _repository;
    private readonly IMemoryCache _cache;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateDestinationCommandHandler"/> class.
    /// </summary>
    /// <param name="repository">The repository used to access and update destination data.</param>
    /// <param name="cache">The memory cache used to invalidate cached destination queries after creation.</param>
    public UpdateDestinationCommandHandler(IDestinationRepository repository, IMemoryCache cache)
    {
        _repository = repository;
        _cache = cache;
    }

    /// <summary>
    /// Handles the command to update a destination.
    /// </summary>
    /// <param name="command">The command containing updated destination details.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns><c>true</c> if the destination was found and updated; otherwise, <c>false</c>.</returns>
    public async Task<bool> Handle(UpdateDestinationCommand command, CancellationToken cancellationToken)
    {
        var destination = await _repository.GetByIdAsync(command.Id, cancellationToken);
        if (destination is null)
        {
            return false;
        }

        destination.Update(command.Name, command.Description, command.CountryId, command.DestinationTypeId, command.IsActive);
        await _repository.UpdateAsync(destination, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
        
        _cache.Remove(Shared.Constants.Cache.AllDestinationsCacheKey);

        return true;
    }
}
