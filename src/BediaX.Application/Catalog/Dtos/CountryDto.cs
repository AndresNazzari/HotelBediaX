namespace BediaX.Application.Catalog.Dtos;

/// <summary>
/// Data transfer object representing a country.
/// </summary>
/// <param name="Id">Unique identifier of the country.</param>
/// <param name="Code">Country code (e.g., ISO code).</param>
/// <param name="Name">Name of the country.</param>
public record CountryDto(int Id, string Code, string Name);