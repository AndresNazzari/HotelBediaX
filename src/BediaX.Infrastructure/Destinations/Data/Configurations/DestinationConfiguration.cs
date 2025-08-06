using BediaX.Domain.Destinations.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BediaX.Infrastructure.Destinations.Data.Configurations;

/// <summary>
/// Entity Framework configuration for the <see cref="Destination"/> entity.
/// </summary>
public class DestinationConfiguration : IEntityTypeConfiguration<Destination>
{
    /// <summary>
    /// Configures the <see cref="Destination"/> entity schema and constraints.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity.</param>
    public void Configure(EntityTypeBuilder<Destination> builder)
    {
        builder.ToTable("Destinations");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(d => d.Description)
            .HasMaxLength(500);

        builder.HasOne(d => d.Country)
            .WithMany()
            .HasForeignKey(d => d.CountryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.DestinationType)
            .WithMany()
            .HasForeignKey(d => d.DestinationTypeId);

        // Soft-delete filter: excludes logically deleted records by default
        builder.HasQueryFilter(d => d.DeletedAt == null);
    }
}