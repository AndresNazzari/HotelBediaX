using BediaX.Application.Catalog.Dtos;
using BediaX.Application.Catalog.Interfaces;
using MediatR;

namespace BediaX.Application.Catalog.Queries;

/// <summary>
/// Handles the <see cref="GetCountriesQuery"/> to retrieve a list of countries.
/// </summary>
internal sealed class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, IReadOnlyList<CountryDto>>
{
    private readonly ICountryRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetCountriesQueryHandler"/> class.
    /// </summary>
    /// <param name="repository">The repository used to access country data.</param>
    public GetCountriesQueryHandler(ICountryRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Handles the query to retrieve all available countries.
    /// </summary>
    /// <param name="query">The query instance (not used directly).</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>A list of <see cref="CountryDto"/> objects.</returns>
    public Task<IReadOnlyList<CountryDto>> Handle(GetCountriesQuery query, CancellationToken cancellationToken)
    {
        return _repository.GetAllAsync(cancellationToken);
    }
}