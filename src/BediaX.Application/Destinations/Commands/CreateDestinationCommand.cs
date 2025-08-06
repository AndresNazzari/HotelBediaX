using MediatR;

namespace BediaX.Application.Destinations.Commands;

/// <summary>
/// Command to create a new destination.
/// </summary>
/// <param name="Name">The name of the destination.</param>
/// <param name="Description">A brief description of the destination.</param>
/// <param name="CountryId">The identifier of the associated country.</param>
/// <param name="DestinationTypeId">The identifier of the destination type.</param>
public record CreateDestinationCommand(
    string Name,
    string Description,
    int CountryId,
    int DestinationTypeId
) : IRequest<int>;