using BediaX.Domain.Destinations.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BediaX.Infrastructure.Destinations.Data.Seed;

internal sealed class CountrySeed : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        var now = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        builder.HasData(
            new { Id = 1, Code = "AR", Name = "Argentina", CreatedAt = now, UpdatedAt = now },
            new { Id = 2, Code = "AU", Name = "Australia", CreatedAt = now, UpdatedAt = now },
            new { Id = 3, Code = "BR", Name = "Brazil", CreatedAt = now, UpdatedAt = now },
            new { Id = 4, Code = "CA", Name = "Canada", CreatedAt = now, UpdatedAt = now },
            new { Id = 5, Code = "CL", Name = "Chile", CreatedAt = now, UpdatedAt = now },
            new { Id = 6, Code = "CN", Name = "China", CreatedAt = now, UpdatedAt = now },
            new { Id = 7, Code = "DE", Name = "Germany", CreatedAt = now, UpdatedAt = now },
            new { Id = 8, Code = "ES", Name = "Spain", CreatedAt = now, UpdatedAt = now },
            new { Id = 9, Code = "FR", Name = "France", CreatedAt = now, UpdatedAt = now },
            new { Id = 10, Code = "GB", Name = "United Kingdom",  CreatedAt = now, UpdatedAt = now },
            new { Id = 11, Code = "IT", Name = "Italy", CreatedAt = now, UpdatedAt = now },
            new { Id = 12, Code = "JP", Name = "Japan", CreatedAt = now, UpdatedAt = now },
            new { Id = 13, Code = "MX", Name = "Mexico", CreatedAt = now, UpdatedAt = now },
            new { Id = 14, Code = "NL", Name = "Netherlands", CreatedAt = now, UpdatedAt = now },
            new { Id = 15, Code = "NZ", Name = "New Zealand", CreatedAt = now, UpdatedAt = now },
            new { Id = 16, Code = "PT", Name = "Portugal", CreatedAt = now, UpdatedAt = now },
            new { Id = 17, Code = "SE", Name = "Sweden", CreatedAt = now, UpdatedAt = now },
            new { Id = 18, Code = "TR", Name = "Türkiye", CreatedAt = now, UpdatedAt = now },
            new { Id = 19, Code = "US", Name = "United States", CreatedAt = now, UpdatedAt = now },
            new { Id = 20, Code = "ZA", Name = "South Africa", CreatedAt = now, UpdatedAt = now }
        );
    }
}
