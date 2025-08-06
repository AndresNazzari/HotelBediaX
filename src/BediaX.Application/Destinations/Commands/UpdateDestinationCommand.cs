using MediatR;

namespace BediaX.Application.Destinations.Commands;

/// <summary>
/// Command to update an existing destination.
/// </summary>
/// <param name="Id">The identifier of the destination to update.</param>
/// <param name="Name">The updated name of the destination.</param>
/// <param name="Description">The updated description of the destination.</param>
/// <param name="CountryId">The updated associated country ID.</param>
/// <param name="DestinationTypeId">The updated destination type ID.</param>
/// <param name="IsActive">Indicates whether the destination is active.</param>
public record UpdateDestinationCommand(
    int Id,
    string Name,
    string Description,
    int CountryId,
    int DestinationTypeId,
    bool IsActive) : IRequest<bool>;