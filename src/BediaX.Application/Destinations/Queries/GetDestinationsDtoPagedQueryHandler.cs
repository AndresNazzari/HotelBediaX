using BediaX.Application.Common.Caching;
using BediaX.Application.Destinations.DTOs;
using BediaX.Application.Destinations.Interfaces;
using BediaX.Shared.Cache;
using BediaX.Shared.Pagination;
using MediatR;

namespace BediaX.Application.Destinations.Queries;

/// <summary>
/// Handles the <see cref="GetDestinationsDtoPagedQuery"/> to retrieve a paginated list of destinations with optional filtering.
/// </summary>
internal sealed class GetDestinationsDtoPagedQueryHandler : IRequestHandler<GetDestinationsDtoPagedQuery, PagedResult<DestinationDto>>
{
    private readonly IDestinationRepository _repository;
    private readonly CacheHelper  _cacheHelper;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetDestinationsDtoPagedQueryHandler"/> class.
    /// </summary>
    /// <param name="repository">The repository used to access paginated destination data.</param>
    /// <param name="cacheHelper">The memory cacheHelper used to invalidate cached destination queries after creation.</param>
    public GetDestinationsDtoPagedQueryHandler(IDestinationRepository repository, CacheHelper cacheHelper)
    {
        _repository = repository;
        _cacheHelper = cacheHelper;
    }

    /// <summary>
    /// Handles the query to retrieve a paginated list of destination DTOs.
    /// </summary>
    /// <param name="query">The query containing pagination and filter parameters.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>A paginated result of <see cref="DestinationDto"/> items.</returns>
    public async Task<PagedResult<DestinationDto>> Handle(GetDestinationsDtoPagedQuery query, CancellationToken cancellationToken)
    { 
        var filterPart = string.IsNullOrWhiteSpace(query.Filter) ? string.Empty : query.Filter.Trim();
        var key = $"{CacheRegions.Destinations}_{query.Page}_{query.PageSize}_{filterPart}";

        var destinations = await _cacheHelper.RememberAsync(
            key,
            CacheRegions.Destinations,
            TimeSpan.FromMinutes(1),
            () => _repository.GetPagedAsync(query.Page, query.PageSize, query.Filter, cancellationToken)
        );
        
        return destinations;
    }
}