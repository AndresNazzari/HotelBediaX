using MediatR;

namespace BediaX.Application.Destinations.Commands;

/// <summary>
/// Command to delete an existing destination by its identifier.
/// </summary>
/// <param name="Id">The identifier of the destination to be deleted.</param>
public record DeleteDestinationCommand(int Id) : IRequest<bool>;