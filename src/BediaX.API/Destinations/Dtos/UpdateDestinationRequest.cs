namespace BediaX.API.Destinations.Dtos;

/// <summary>
/// Request data for updating an existing destination.
/// </summary>
/// <param name="Name">Name of the destination.</param>
/// <param name="Description">Description of the destination.</param>
/// <param name="CountryId">Identifier of the country where the destination is located.</param>
/// <param name="DestinationTypeId">Identifier of the destination type.</param>
/// <param name="IsActive">Indicates if the destination is active.</param>
public record UpdateDestinationRequest(
    string Name,
    string Description,
    int CountryId,
    int DestinationTypeId,
    bool IsActive);