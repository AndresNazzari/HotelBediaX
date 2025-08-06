namespace BediaX.Shared.Pagination;

/// <summary>
/// Represents a paginated result set with items and the total count.
/// </summary>
/// <typeparam name="T">The type of the items in the result set.</typeparam>
public class PagedResult<T>
{
    /// <summary>
    /// Gets the list of items in the current page.
    /// </summary>
    public required IReadOnlyList<T> Items { get; init; }

    /// <summary>
    /// Gets the total number of items that match the query (before pagination).
    /// </summary>
    public required int Total { get; init; }
}