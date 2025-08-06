using Microsoft.Extensions.Caching.Memory;

namespace BediaX.Shared.Cache;

public static class CacheHelper
{
    public static async Task<T> RememberAsync<T>(
        this IMemoryCache cache,
        string key,
        TimeSpan ttl,
        Func<Task<T>> factory)
    {
        if (cache.TryGetValue(key, out T value))
        {
            return value;
        }

        value = await factory();
        cache.Set(key, value, ttl);
        return value;
    }
}