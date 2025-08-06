using BediaX.Application.Destinations.DTOs;
using BediaX.Shared.Pagination;
using MediatR;

namespace BediaX.Application.Destinations.Queries;

/// <summary>
/// Query to retrieve a paginated list of destinations with optional filtering.
/// </summary>
/// <param name="Page">The page number to retrieve (default is 1).</param>
/// <param name="PageSize">The number of items per page (default is 20).</param>
/// <param name="Filter">An optional search term to filter destinations by name or description.</param>
public record GetDestinationsDtoPagedQuery(
    int Page = 1,
    int PageSize = 20,
    string? Filter = null
) : IRequest<PagedResult<DestinationDto>>;