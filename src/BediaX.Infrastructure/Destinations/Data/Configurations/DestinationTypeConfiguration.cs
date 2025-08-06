using BediaX.Domain.Destinations.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BediaX.Infrastructure.Destinations.Data.Configurations;

/// <summary>
/// Entity Framework configuration for the <see cref="DestinationType"/> entity.
/// </summary>
public class DestinationTypeConfiguration : IEntityTypeConfiguration<DestinationType>
{
    /// <summary>
    /// Configures the <see cref="DestinationType"/> entity schema and constraints.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity.</param>
    public void Configure(EntityTypeBuilder<DestinationType> builder)
    {
        builder.ToTable("DestinationTypes");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(30);
    }
}