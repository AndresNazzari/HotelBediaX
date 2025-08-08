using BediaX.Application.Common.Caching;
using BediaX.Shared.Cache;
using Microsoft.AspNetCore.Mvc;

namespace BediaX.API.Cache.Controllers;

/// <summary>
/// Controller responsible for cache management operations, such as invalidating specific cache regions.
/// </summary>
/// <remarks>
/// This controller provides endpoints for managing application cache.
/// By using the provided services, specific cache regions can be invalidated,
/// ensuring consistency of data across the application.
/// </remarks>
[ApiController]
[Route("api/cache")]
public class CacheController : ControllerBase
{
    private readonly ICacheRegionService _cacheRegionService;

    /// <summary>
    /// Controller responsible for cache management operations, such as invalidating specific cache regions.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for managing application cache. By using the provided services,
    /// specific cache regions can be invalidated, ensuring consistency of data across the application.
    /// </remarks>
    public CacheController(ICacheRegionService cacheRegionService)
    {
        _cacheRegionService = cacheRegionService;
    }

    /// <summary>
    /// Clears the cache associated with the destination region.
    /// </summary>
    /// <remarks>
    /// This method invalidates the cache for the destination region using the provided cache region service.
    /// It ensures that stale or outdated data related to destinations is removed from the cache,
    /// maintaining data consistency across the application.
    /// </remarks>
    /// <returns>
    /// An HTTP response confirming that the destination cache has been cleared.
    /// </returns>
    [HttpDelete("destinations")]
    public IActionResult ClearDestinations()
    {
        _cacheRegionService.InvalidateRegion(CacheRegions.Destinations);
        return Ok("Destinations cache cleared");
    }
}