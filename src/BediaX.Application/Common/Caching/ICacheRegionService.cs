using Microsoft.Extensions.Primitives;

namespace BediaX.Application.Common.Caching;

// <summary>
// Interface for managing cache regions, allowing for the retrieval of change tokens
// and the invalidation of cached data within specific regions.
// </summary>
// <remarks>
// This interface is used to define operations for cache region management, enabling
// efficient cache invalidation and change tracking across different parts of the application.
// </remarks>
public interface ICacheRegionService
{
    IChangeToken GetRegionToken(string regionName);
    void InvalidateRegion(string regionName);
}