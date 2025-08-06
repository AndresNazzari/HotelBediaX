using BediaX.Application.Destinations.DTOs;
using BediaX.Application.Destinations.Interfaces;
using MediatR;

namespace BediaX.Application.Destinations.Queries;

/// <summary>
/// Handles the <see cref="GetDestinationDtoByIdQuery"/> to retrieve a destination as a DTO by its ID.
/// </summary>
internal sealed class GetDestinationDtoByIdQueryHandler : IRequestHandler<GetDestinationDtoByIdQuery, DestinationDto?>
{
    private readonly IDestinationRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetDestinationDtoByIdQueryHandler"/> class.
    /// </summary>
    /// <param name="repository">The repository used to access destination data.</param>
    public GetDestinationDtoByIdQueryHandler(IDestinationRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Handles the query to retrieve a destination by its identifier.
    /// </summary>
    /// <param name="query">The query containing the destination ID.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>A <see cref="DestinationDto"/> if found; otherwise, <c>null</c>.</returns>
    public Task<DestinationDto?> Handle(GetDestinationDtoByIdQuery query, CancellationToken cancellationToken)
    {
        return _repository.GetDtoByIdAsync(query.Id, cancellationToken);
    }
}
