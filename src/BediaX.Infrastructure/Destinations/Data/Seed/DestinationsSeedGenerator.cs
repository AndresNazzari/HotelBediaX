using System.Text;
using Bogus;

namespace BediaX.Infrastructure.Destinations.Data.Seed;

internal static class DestinationsSeedGenerator
{
    internal static IEnumerable<string> GenerateBatches(int totalRows, int batchSize)
    {
        var faker = new Faker("en");

        var cIds = Enumerable.Range(1, 20).ToArray();
        var tIds = Enumerable.Range(1, 4).ToArray();

        var sb = new StringBuilder();
        const string header =
            "INSERT INTO Destinations " +
            "(Name, Description, IsActive, CountryId, DestinationTypeId, CreatedAt, UpdatedAt) VALUES ";

        sb.Append(header);

        var rowsInBatch = 0;

        for (var i = 0; i < totalRows; i++)
        {
            var name = $"{faker.Address.City()} {faker.PickRandom("Resort","Hotel","Spa")}"
                .Replace("'", "''");
            var desc = faker.Lorem.Sentence(8).Replace("'", "''");
            var cId  = faker.PickRandom(cIds);
            var tId  = faker.PickRandom(tIds);
            const string now = "2025-01-01 00:00:00";

            sb.Append($"('{name}','{desc}',1,{cId},{tId},'{now}','{now}')");

            rowsInBatch++;
            var isLastRow   = i == totalRows - 1;
            var endOfBatch  = rowsInBatch == batchSize;

            sb.Append(isLastRow || endOfBatch ? ";\n" : ",\n");

            if (!endOfBatch && !isLastRow)
            {
                continue;
            }
            
            yield return sb.ToString();
            sb.Clear();
            if (!isLastRow) sb.Append(header);
            rowsInBatch = 0;
        }
    }

}
