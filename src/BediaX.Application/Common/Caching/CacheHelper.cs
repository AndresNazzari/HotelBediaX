using Microsoft.Extensions.Caching.Memory;

namespace BediaX.Application.Common.Caching;

/// <summary>
/// Provides caching functionality using the in-memory cache mechanism,
/// with support for cache expiration and region-based invalidation.
/// </summary>
public class CacheHelper
{
    private readonly IMemoryCache _memoryCache;
    private readonly ICacheRegionService _cacheRegionService;

    /// <summary>
    /// Provides caching functionality using an in-memory cache with support for
    /// cache expiration policies and region-based invalidation.
    /// </summary>
    public CacheHelper(IMemoryCache memoryCache, ICacheRegionService cacheRegionService)
    {
        _memoryCache = memoryCache;
        _cacheRegionService = cacheRegionService;
    }

    /// <summary>
    /// Retrieves a value from the cache if available, or executes a factory method to generate
    /// the value, stores it in the cache with specified expiration and region invalidation settings,
    /// and then returns the value.
    /// </summary>
    /// <typeparam name="T">The type of the value to retrieve or create.</typeparam>
    /// <param name="key">The unique cache key for storing and retrieving the value.</param>
    /// <param name="regionName">The name of the cache region used for invalidation.</param>
    /// <param name="ttl">The time-to-live duration for the cache entry.</param>
    /// <param name="factory">A function that generates the value if it does not exist in the cache.</param>
    /// <returns>A task representing the asynchronous operation, with the cached or generated value as the result.</returns>
    public async Task<T> RememberAsync<T>(
        string key,
        string regionName,
        TimeSpan ttl,
        Func<Task<T>> factory)
    {
        if (_memoryCache.TryGetValue<T>(key, out var cached))
        {
            return cached!;
        }

        var value = await factory();

        var options = new MemoryCacheEntryOptions()
            .SetAbsoluteExpiration(ttl)
            .AddExpirationToken(_cacheRegionService.GetRegionToken(regionName));

        _memoryCache.Set(key, value, options);
        return value;
    }
}