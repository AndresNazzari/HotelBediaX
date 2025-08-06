using BediaX.Application.Catalog.Dtos;
using MediatR;

namespace BediaX.Application.Catalog.Queries;

/// <summary>
/// Query to retrieve the list of all available destination types.
/// </summary>
public record GetDestinationTypesQuery() : IRequest<IReadOnlyList<DestinationTypeDto>>;