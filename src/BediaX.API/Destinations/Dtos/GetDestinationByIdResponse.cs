namespace BediaX.API.Destinations.Dtos;

/// <summary>
/// Response data for retrieving a destination by its identifier.
/// </summary>
/// <param name="Id">Unique identifier of the destination.</param>
/// <param name="Name">Name of the destination.</param>
/// <param name="Description">Description of the destination.</param>
/// <param name="IsActive">Indicates if the destination is active.</param>
/// <param name="Country">Name of the country where the destination is located.</param>
/// <param name="DestinationType">Type of the destination.</param>
public record GetDestinationByIdResponse(
    int Id,
    string Name,
    string Description,
    bool IsActive,
    string Country,
    string DestinationType);