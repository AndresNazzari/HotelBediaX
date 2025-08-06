using BediaX.Domain.Destinations.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BediaX.Infrastructure.Destinations.Data.Configurations;

/// <summary>
/// Entity Framework configuration for the <see cref="Country"/> entity.
/// </summary>
public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    /// <summary>
    /// Configures the <see cref="Country"/> entity schema and constraints.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity.</param>
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("Countries");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Code)
            .IsRequired()
            .HasMaxLength(2)
            .IsFixedLength();

        builder.HasIndex(c => c.Code)
            .IsUnique()
            .HasDatabaseName("UX_Countries_Code");

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(80);
    }
}