using BediaX.Application.Destinations.DTOs;

namespace BediaX.API.Destinations.Dtos;

/// <summary>
/// Response data for a paginated list of destinations.
/// </summary>
/// <param name="Page">Current page number.</param>
/// <param name="PageSize">Number of items per page.</param>
/// <param name="TotalItems">Total number of items available.</param>
/// <param name="TotalPages">Total number of pages available.</param>
/// <param name="HasNext">Indicates if there is a next page.</param>
/// <param name="HasPrevious">Indicates if there is a previous page.</param>
/// <param name="Items">List of destination items for the current page.</param>
public record GetDestinationsResponse(
    int Page,
    int PageSize,
    int TotalItems,
    int TotalPages,
    bool HasNext,
    bool HasPrevious,
    IEnumerable<DestinationDto> Items);