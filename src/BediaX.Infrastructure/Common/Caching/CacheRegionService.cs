using System.Collections.Concurrent;
using BediaX.Application.Common.Caching;
using Microsoft.Extensions.Primitives;

namespace BediaX.Infrastructure.Common.Caching;

/// <summary>
/// Service implementation for managing cache regions, which enables grouping and invalidation
/// of related cached data entries via region tokens.
/// </summary>
public class CacheRegionService : ICacheRegionService
{
    private readonly ConcurrentDictionary<string, CancellationTokenSource> _regions = new();

    /// <summary>
    /// Retrieves a change token associated with the specified cache region.
    /// This token can be used to monitor changes or invalidations occurring in the given region.
    /// </summary>
    /// <param name="regionName">The name of the cache region to retrieve the token for.</param>
    /// <returns>An <see cref="IChangeToken"/> that represents the change detection token for the specified region.</returns>
    public IChangeToken GetRegionToken(string regionName)
    {
        var cts = _regions.GetOrAdd(regionName, _ => new CancellationTokenSource());
        return new CancellationChangeToken(cts.Token);
    }

    /// <summary>
    /// Invalidates the specified cache region, triggering any associated change tokens
    /// and resetting the region for further cache operations.
    /// </summary>
    /// <param name="regionName">The name of the cache region to be invalidated.</param>
    public void InvalidateRegion(string regionName)
    {
        if (_regions.TryRemove(regionName, out var cts))
        {
            try { cts.Cancel(); }
            finally { cts.Dispose(); }
        }

        _regions.TryAdd(regionName, new CancellationTokenSource());
    }
}
