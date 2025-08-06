using BediaX.Application.Destinations.Interfaces;
using BediaX.Domain.Destinations.Entities;
using MediatR;

namespace BediaX.Application.Destinations.Commands;

/// <summary>
/// Handles the <see cref="CreateDestinationCommand"/> to create a new destination.
/// </summary>
internal sealed class CreateDestinationCommandHandler : IRequestHandler<CreateDestinationCommand, int>
{
    private readonly IDestinationRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateDestinationCommandHandler"/> class.
    /// </summary>
    /// <param name="repository">The repository used to persist the destination entity.</param>
    public CreateDestinationCommandHandler(IDestinationRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Handles the command to create a new destination.
    /// </summary>
    /// <param name="command">The command containing destination details.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>The identifier of the newly created destination.</returns>
    public async Task<int> Handle(CreateDestinationCommand command, CancellationToken cancellationToken)
    {
        var destination = Destination.Create(
            command.Name,
            command.Description,
            command.CountryId,
            command.DestinationTypeId);

        await _repository.AddAsync(destination, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);

        return destination.Id;
    }
}