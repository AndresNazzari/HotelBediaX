using BediaX.Application.Catalog.Dtos;
using BediaX.Application.Catalog.Interfaces;
using MediatR;

namespace BediaX.Application.Catalog.Queries;

/// <summary>
/// Handles the <see cref="GetDestinationTypesQuery"/> to retrieve a list of destination types.
/// </summary>
internal sealed class GetDestinationTypesQueryHandler
    : IRequestHandler<GetDestinationTypesQuery, IReadOnlyList<DestinationTypeDto>>
{
    private readonly IDestinationTypeRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetDestinationTypesQueryHandler"/> class.
    /// </summary>
    /// <param name="repository">The repository used to access destination type data.</param>
    public GetDestinationTypesQueryHandler(IDestinationTypeRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Handles the query to retrieve all available destination types.
    /// </summary>
    /// <param name="query">The query instance (not used directly).</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>A list of <see cref="DestinationTypeDto"/> objects.</returns>
    public Task<IReadOnlyList<DestinationTypeDto>> Handle(GetDestinationTypesQuery query, CancellationToken cancellationToken)
    {
        return _repository.GetAllAsync(cancellationToken);
    }
}