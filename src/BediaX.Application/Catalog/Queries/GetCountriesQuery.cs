using BediaX.Application.Catalog.Dtos;
using MediatR;

namespace BediaX.Application.Catalog.Queries;

/// <summary>
/// Query to retrieve the list of all available countries.
/// </summary>
public record GetCountriesQuery() : IRequest<IReadOnlyList<CountryDto>>;