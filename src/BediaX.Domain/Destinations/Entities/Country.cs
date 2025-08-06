namespace BediaX.Domain.Destinations.Entities;

/// <summary>
/// Represents a country in the system.
/// </summary>
public class Country
{
    /// <summary>
    /// Gets the unique identifier of the country.
    /// </summary>
    public int Id { get; private set; }

    /// <summary>
    /// Gets the ISO or custom code of the country.
    /// </summary>
    public string Code { get; private set; } = default!;

    /// <summary>
    /// Gets the name of the country.
    /// </summary>
    public string Name { get; private set; } = default!;

    /// <summary>
    /// Gets the date and time when the country was created.
    /// </summary>
    public DateTime CreatedAt { get; private set; }

    /// <summary>
    /// Gets the date and time when the country was last updated.
    /// </summary>
    public DateTime UpdatedAt { get; private set; }

    /// <summary>
    /// Required by EF Core. Do not use directly.
    /// </summary>
    private Country() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Country"/> class with the specified code and name.
    /// </summary>
    /// <param name="code">The country code.</param>
    /// <param name="name">The country name.</param>
    public Country(string code, string name)
    {
        Code = code;
        Name = name;
        CreatedAt = UpdatedAt = DateTime.UtcNow;
    }
}