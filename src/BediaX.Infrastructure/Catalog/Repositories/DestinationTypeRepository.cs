using BediaX.Application.Catalog.Dtos;
using BediaX.Application.Catalog.Interfaces;
using BediaX.Infrastructure.Destinations.Data;
using Microsoft.EntityFrameworkCore;

namespace BediaX.Infrastructure.Catalog.Repositories;

/// <summary>
/// Repository implementation for accessing destination type data from the database.
/// </summary>
internal sealed class DestinationTypeRepository : IDestinationTypeRepository
{
    private readonly BediaXDbContext _dbContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="DestinationTypeRepository"/> class.
    /// </summary>
    /// <param name="dbContext">The database context used to access destination type data.</param>
    public DestinationTypeRepository(BediaXDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Retrieves all destination types as DTOs.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>A list of <see cref="DestinationTypeDto"/> objects.</returns>
    public async Task<IReadOnlyList<DestinationTypeDto>> GetAllAsync(CancellationToken cancellationToken) =>
        await _dbContext.DestinationTypes
            .AsNoTracking()
            .Select(t => new DestinationTypeDto(t.Id, t.Name))
            .ToListAsync(cancellationToken);
}