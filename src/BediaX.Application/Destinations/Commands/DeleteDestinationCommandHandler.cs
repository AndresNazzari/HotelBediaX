using BediaX.Application.Destinations.Interfaces;
using MediatR;

namespace BediaX.Application.Destinations.Commands;

/// <summary>
/// Handles the <see cref="DeleteDestinationCommand"/> to perform a soft delete of a destination.
/// </summary>
internal sealed class DeleteDestinationCommandHandler : IRequestHandler<DeleteDestinationCommand, bool>
{
    private readonly IDestinationRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteDestinationCommandHandler"/> class.
    /// </summary>
    /// <param name="repository">The repository used to access and update destination data.</param>
    public DeleteDestinationCommandHandler(IDestinationRepository repository) 
    {
        _repository = repository;
    }

    /// <summary>
    /// Handles the command to soft-delete a destination by its identifier.
    /// </summary>
    /// <param name="command">The command containing the destination ID to be deleted.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns><c>true</c> if the destination was found and deleted; otherwise, <c>false</c>.</returns>
    public async Task<bool> Handle(DeleteDestinationCommand command, CancellationToken cancellationToken)
    {
        var dest = await _repository.GetByIdAsync(command.Id, cancellationToken);
        if (dest is null)
        {
            return false;
        }

        await _repository.SoftDeleteAsync(dest, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
        return true;
    }
}