namespace BediaX.Domain.Destinations.Entities;

/// <summary>
/// Represents a travel destination within the system.
/// </summary>
public class Destination
{
    /// <summary>
    /// Gets the unique identifier of the destination.
    /// </summary>
    public int Id { get; private set; }

    /// <summary>
    /// Gets the name of the destination.
    /// </summary>
    public string Name { get; private set; } = default!;

    /// <summary>
    /// Gets the description of the destination.
    /// </summary>
    public string Description { get; private set; } = default!;

    /// <summary>
    /// Indicates whether the destination is currently active.
    /// </summary>
    public bool IsActive { get; private set; } = true;

    // Foreign Keys

    /// <summary>
    /// Gets the ID of the associated country.
    /// </summary>
    public int CountryId { get; private set; }

    /// <summary>
    /// Gets the associated country.
    /// </summary>
    public Country Country { get; private set; } = default!;

    /// <summary>
    /// Gets the ID of the associated destination type.
    /// </summary>
    public int DestinationTypeId { get; private set; }

    /// <summary>
    /// Gets the associated destination type.
    /// </summary>
    public DestinationType DestinationType { get; private set; } = default!;

    /// <summary>
    /// Gets the date and time when the destination was created.
    /// </summary>
    public DateTime CreatedAt  { get; private set; }

    /// <summary>
    /// Gets the date and time when the destination was last updated.
    /// </summary>
    public DateTime UpdatedAt  { get; private set; }

    /// <summary>
    /// Gets the date and time when the destination was soft-deleted, if applicable.
    /// </summary>
    public DateTime? DeletedAt { get; private set; }

    /// <summary>
    /// Required by EF Core. Do not use directly.
    /// </summary>
    private Destination() { }

    /// <summary>
    /// Factory method to create a new destination.
    /// </summary>
    /// <param name="name">The name of the destination.</param>
    /// <param name="description">The description of the destination.</param>
    /// <param name="countryId">The ID of the associated country.</param>
    /// <param name="destinationTypeId">The ID of the destination type.</param>
    /// <returns>A new <see cref="Destination"/> instance.</returns>
    /// <exception cref="ArgumentException">Thrown if the name is null or whitespace.</exception>
    public static Destination Create(
        string name,
        string description,
        int countryId,
        int destinationTypeId)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name is required", nameof(name));
        }

        var now = DateTime.UtcNow;

        return new Destination
        {
            Name = name,
            Description = description,
            CountryId = countryId,
            DestinationTypeId = destinationTypeId,
            CreatedAt = now,
            UpdatedAt = now,
            IsActive = true
        };
    }

    /// <summary>
    /// Updates the destination with new values.
    /// </summary>
    /// <param name="name">The updated name.</param>
    /// <param name="description">The updated description.</param>
    /// <param name="countryId">The updated country ID.</param>
    /// <param name="destinationTypeId">The updated destination type ID.</param>
    /// <param name="isActive">The updated active status.</param>
    public void Update(
        string name,
        string description,
        int countryId,
        int destinationTypeId,
        bool isActive)
    {
        Name = name;
        Description = description;
        CountryId = countryId;
        DestinationTypeId = destinationTypeId;
        IsActive = isActive;
        UpdatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Performs a soft delete by setting the <see cref="DeletedAt"/> timestamp.
    /// </summary>
    public void SoftDelete() => DeletedAt = DateTime.UtcNow;
}
