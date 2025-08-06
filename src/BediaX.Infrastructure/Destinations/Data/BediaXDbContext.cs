using BediaX.Domain.Destinations.Entities;
using Microsoft.EntityFrameworkCore;

namespace BediaX.Infrastructure.Destinations.Data;

/// <summary>
/// The Entity Framework database context for the BediaX application.
/// It defines the entity sets and applies configurations for the data model.
/// </summary>
public class BediaXDbContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BediaXDbContext"/> class.
    /// </summary>
    /// <param name="options">The options to configure the DbContext.</param>
    public BediaXDbContext(DbContextOptions<BediaXDbContext> options)
        : base(options) { }

    /// <summary>
    /// Gets the table for countries.
    /// </summary>
    public DbSet<Country> Countries => Set<Country>();

    /// <summary>
    /// Gets the table for destination types.
    /// </summary>
    public DbSet<DestinationType> DestinationTypes => Set<DestinationType>();

    /// <summary>
    /// Gets the table for destinations.
    /// </summary>
    public DbSet<Destination> Destinations => Set<Destination>();

    /// <summary>
    /// Applies all entity configurations from the current assembly.
    /// </summary>
    /// <param name="modelBuilder">The builder used to construct the model for the context.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BediaXDbContext).Assembly);
    }
}