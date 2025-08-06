using BediaX.Infrastructure.Destinations.Data.Seed;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BediaX.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seed_Destinations : Migration
    {
        private const int TotalRows = 250000;
        private const int BatchSize = 5000;
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            foreach (var sqlBatch in DestinationsSeedGenerator.GenerateBatches(TotalRows, BatchSize))
            {
                migrationBuilder.Sql(sqlBatch);
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DELETE FROM Destinations WHERE Id <= {TotalRows};");
        }
    }
}
