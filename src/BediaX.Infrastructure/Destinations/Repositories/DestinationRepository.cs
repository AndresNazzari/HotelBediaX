using BediaX.Application.Destinations.DTOs;
using BediaX.Application.Destinations.Interfaces;
using BediaX.Domain.Destinations.Entities;
using BediaX.Infrastructure.Destinations.Data;
using BediaX.Shared.Pagination;
using Microsoft.EntityFrameworkCore;

namespace BediaX.Infrastructure.Destinations.Repositories;

/// <summary>
/// Repository implementation for managing and retrieving destination data from the database.
/// </summary>
public class DestinationRepository : IDestinationRepository
{
    private readonly BediaXDbContext _dbContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="DestinationRepository"/> class.
    /// </summary>
    /// <param name="dbContext">The application's database context.</param>
    public DestinationRepository(BediaXDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Adds a new destination to the database context.
    /// </summary>
    /// <param name="destination">The destination entity to add.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    public async Task AddAsync(Destination destination, CancellationToken cancellationToken)
    {
        await _dbContext.Destinations.AddAsync(destination, cancellationToken);
    }

    /// <summary>
    /// Retrieves a destination by its ID and projects it as a <see cref="DestinationDto"/>.
    /// Includes related entities like Country and DestinationType.
    /// </summary>
    /// <param name="id">The destination ID.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>The destination as a DTO, or null if not found.</returns>
    public async Task<DestinationDto?> GetDtoByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _dbContext.Destinations
            .Where(d => d.Id == id)
            .Select(d => new DestinationDto(
                d.Id,
                d.Name,
                d.Description,
                d.IsActive,
                d.Country.Name,
                d.DestinationType.Name))
            .FirstOrDefaultAsync(cancellationToken);
    }

    /// <summary>
    /// Retrieves a destination entity by its ID.
    /// </summary>
    /// <param name="id">The destination ID.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>The destination entity, or null if not found.</returns>
    public Task<Destination?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return _dbContext.Destinations.FirstOrDefaultAsync(d => d.Id == id, cancellationToken);
    }

    /// <summary>
    /// Retrieves a paginated list of destination DTOs with optional name filtering.
    /// </summary>
    /// <param name="page">The page number (starting at 1).</param>
    /// <param name="pageSize">The number of items per page.</param>
    /// <param name="filter">Optional name filter to apply.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>A paginated result containing destination DTOs.</returns>
    public async Task<PagedResult<DestinationDto>> GetPagedAsync(int page, int pageSize, string? filter, CancellationToken cancellationToken)
    {
        var query = _dbContext.Destinations.AsQueryable();

        if (!string.IsNullOrWhiteSpace(filter))
        {
            query = query.Where(d => d.Name.Contains(filter));
        }

        var total = await query.CountAsync(cancellationToken);

        var items = await query
            .OrderBy(d => d.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(d => new DestinationDto(
                d.Id,
                d.Name,
                d.Description,
                d.IsActive,
                d.Country.Name,
                d.DestinationType.Name))
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return new PagedResult<DestinationDto> { Items = items, Total = total };
    }

    /// <summary>
    /// Updates an existing destination in the context.
    /// </summary>
    /// <param name="destination">The updated destination entity.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    public Task UpdateAsync(Destination destination, CancellationToken cancellationToken)
    {
        _dbContext.Destinations.Update(destination);
        return Task.CompletedTask;
    }

    /// <summary>
    /// Performs a soft delete by marking the destination as deleted without removing it from the database.
    /// </summary>
    /// <param name="destination">The destination to be soft deleted.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    public Task SoftDeleteAsync(Destination destination, CancellationToken cancellationToken)
    {
        destination.SoftDelete();
        _dbContext.Destinations.Update(destination);
        return Task.CompletedTask;
    }

    /// <summary>
    /// Persists all pending changes in the database context.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>The number of affected rows.</returns>
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }
}