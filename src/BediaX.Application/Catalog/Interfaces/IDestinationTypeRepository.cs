using BediaX.Application.Catalog.Dtos;

namespace BediaX.Application.Catalog.Interfaces;

/// <summary>
/// Defines the operations to access the available destination types in the system.
/// </summary>
public interface IDestinationTypeRepository
{
    /// <summary>
    /// Retrieves the list of all available destination types.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>A list of <see cref="DestinationTypeDto"/> objects.</returns>
    Task<IReadOnlyList<DestinationTypeDto>> GetAllAsync(CancellationToken cancellationToken);
}