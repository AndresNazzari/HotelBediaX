namespace BediaX.Application.Destinations.DTOs;

/// <summary>
/// Data Transfer Object representing a destination.
/// </summary>
/// <param name="Id">The unique identifier of the destination.</param>
/// <param name="Name">The name of the destination.</param>
/// <param name="Description">A brief description of the destination.</param>
/// <param name="IsActive">Indicates whether the destination is active.</param>
/// <param name="Country">The name of the associated country.</param>
/// <param name="DestinationType">The type/category of the destination.</param>
public record DestinationDto(
    int Id,
    string Name,
    string Description,
    bool IsActive,
    string Country,
    string DestinationType);