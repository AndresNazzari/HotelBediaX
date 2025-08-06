using BediaX.Application.Destinations.DTOs;
using MediatR;

namespace BediaX.Application.Destinations.Queries;

/// <summary>
/// Query to retrieve a destination as a DTO by its identifier.
/// </summary>
/// <param name="Id">The identifier of the destination.</param>
public record GetDestinationDtoByIdQuery(int Id) : IRequest<DestinationDto?>;