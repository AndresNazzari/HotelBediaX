namespace BediaX.Domain.Destinations.Entities;

/// <summary>
/// Represents the type or category of a destination (e.g., beach, city, mountain).
/// </summary>
public class DestinationType
{
    /// <summary>
    /// Gets the unique identifier of the destination type.
    /// </summary>
    public int Id { get; private set; }

    /// <summary>
    /// Gets the name of the destination type.
    /// </summary>
    public string Name { get; private set; } = default!;

    /// <summary>
    /// Gets the date and time when the destination type was created.
    /// </summary>
    public DateTime CreatedAt { get; private set; }

    /// <summary>
    /// Gets the date and time when the destination type was last updated.
    /// </summary>
    public DateTime UpdatedAt { get; private set; }

    /// <summary>
    /// Required by EF Core. Do not use directly.
    /// </summary>
    private DestinationType() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="DestinationType"/> class with the specified name.
    /// </summary>
    /// <param name="name">The name of the destination type.</param>
    public DestinationType(string name)
    {
        Name = name;
        CreatedAt = UpdatedAt = DateTime.UtcNow;
    }
}