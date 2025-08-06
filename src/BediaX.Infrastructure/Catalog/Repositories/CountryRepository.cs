using BediaX.Application.Catalog.Dtos;
using BediaX.Application.Catalog.Interfaces;
using BediaX.Infrastructure.Destinations.Data;
using Microsoft.EntityFrameworkCore;

namespace BediaX.Infrastructure.Catalog.Repositories;

/// <summary>
/// Repository implementation for accessing country data from the database.
/// </summary>
internal sealed class CountryRepository : ICountryRepository
{
    private readonly BediaXDbContext _dbContextContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="CountryRepository"/> class.
    /// </summary>
    /// <param name="dbContext">The database context used to access country data.</param>
    public CountryRepository(BediaXDbContext dbContext)
    {
        _dbContextContext = dbContext;
    }

    /// <summary>
    /// Retrieves all countries as DTOs.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>A list of <see cref="CountryDto"/> objects.</returns>
    public async Task<IReadOnlyList<CountryDto>> GetAllAsync(CancellationToken cancellationToken) =>
        await _dbContextContext.Countries
            .AsNoTracking()
            .Select(c => new CountryDto(c.Id, c.Code, c.Name))
            .ToListAsync(cancellationToken);
}