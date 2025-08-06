using BediaX.Application.Catalog.Dtos;

namespace BediaX.Application.Catalog.Interfaces;

/// <summary>
/// Defines the operations to access the available countries in the system.
/// </summary>
public interface ICountryRepository
{
    /// <summary>
    /// Retrieves the list of all available countries.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>A list of <see cref="CountryDto"/> objects.</returns>
    Task<IReadOnlyList<CountryDto>> GetAllAsync(CancellationToken cancellationToken);
}