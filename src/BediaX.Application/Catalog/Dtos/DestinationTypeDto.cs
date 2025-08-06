namespace BediaX.Application.Catalog.Dtos;

/// <summary>
/// Data transfer object representing a destination type.
/// </summary>
/// <param name="Id">Unique identifier of the destination type.</param>
/// <param name="Name">Name of the destination type.</param>
public record DestinationTypeDto(int Id, string Name);