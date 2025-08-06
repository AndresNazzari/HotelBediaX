namespace BediaX.API.Destinations.Dtos;

/// <summary>
/// Request payload used to create a new destination.
/// </summary>
/// <param name="Name">Destination name (e.g.<c>"Playa Blanca Resort"</c>).</param>
/// <param name="Description">Short, human-readable description (max=500 chars).</param>
/// <param name="CountryId">Foreign-key identifier of the country where the destination is located.</param>
/// <param name="DestinationTypeId">Foreign-key identifier of the destination type (Beach, Mountain, etc.).</param>
public record CreateDestinationRequest(
    string Name,
    string Description,
    int CountryId,
    int DestinationTypeId);