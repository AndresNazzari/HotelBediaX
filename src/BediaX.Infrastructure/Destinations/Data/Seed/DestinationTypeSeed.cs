using BediaX.Domain.Destinations.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BediaX.Infrastructure.Destinations.Data.Seed;

internal sealed class DestinationTypeSeed : IEntityTypeConfiguration<DestinationType>
{
    public void Configure(EntityTypeBuilder<DestinationType> builder)
    {
        var now = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        builder.HasData(
            new { Id = 1, Name = "Beach", CreatedAt = now, UpdatedAt = now },
            new { Id = 2, Name = "Mountain", CreatedAt = now, UpdatedAt = now },
            new { Id = 3, Name = "City", CreatedAt = now, UpdatedAt = now },
            new { Id = 4, Name = "Countryside", CreatedAt = now, UpdatedAt = now }
        );
    }
}