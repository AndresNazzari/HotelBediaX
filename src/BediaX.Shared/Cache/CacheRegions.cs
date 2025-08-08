namespace BediaX.Shared.Cache;

/// <summary>
/// Provides a centralized location for defining cache region names used throughout the application.
/// </summary>
/// <remarks>
/// Cache regions are useful for grouping related cache entries together. They allow for bulk invalidation
/// of cache entries that belong to the same region, improving cache management and consistency when data changes.
/// </remarks>
public static class CacheRegions
{
    /// <summary>
    /// Represents the cache region name used for storing, retrieving,
    /// and invalidating cache related to destinations.
    /// This constant is used to group cached data for destinations,
    /// ensuring effective invalidation and organization of cached content.
    /// </summary>
    public const string Destinations = "Destinations";
}