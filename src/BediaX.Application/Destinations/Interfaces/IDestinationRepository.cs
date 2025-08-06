using BediaX.Application.Destinations.DTOs;
using BediaX.Domain.Destinations.Entities;
using BediaX.Shared.Pagination;

namespace BediaX.Application.Destinations.Interfaces;

/// <summary>
/// Defines the contract for managing destination entities and accessing destination data.
/// </summary>
public interface IDestinationRepository
{
    /// <summary>
    /// Adds a new destination entity to the context.
    /// </summary>
    /// <param name="destination">The destination entity to add.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    Task AddAsync(Destination destination, CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a destination as a DTO by its identifier.
    /// </summary>
    /// <param name="id">The destination identifier.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>A <see cref="DestinationDto"/> if found; otherwise, null.</returns>
    Task<DestinationDto?> GetDtoByIdAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a destination entity by its identifier.
    /// </summary>
    /// <param name="id">The destination identifier.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>A <see cref="Destination"/> entity if found; otherwise, null.</returns>
    Task<Destination?> GetByIdAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a paginated list of destination DTOs based on the given filter and paging parameters.
    /// </summary>
    /// <param name="page">The page number (starting at 1).</param>
    /// <param name="pageSize">The number of items per page.</param>
    /// <param name="filter">Optional filter string to match destination names or descriptions.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>A paginated result of <see cref="DestinationDto"/> items.</returns>
    Task<PagedResult<DestinationDto>> GetPagedAsync(int page, int pageSize, string? filter, CancellationToken cancellationToken);

    /// <summary>
    /// Updates an existing destination entity.
    /// </summary>
    /// <param name="destination">The destination entity with updated values.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    Task UpdateAsync(Destination destination, CancellationToken cancellationToken);

    /// <summary>
    /// Performs a soft delete on a destination entity.
    /// </summary>
    /// <param name="destination">The destination entity to soft-delete.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    Task SoftDeleteAsync(Destination destination, CancellationToken cancellationToken);

    /// <summary>
    /// Persists all pending changes to the data store.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>The number of state entries written to the database.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
