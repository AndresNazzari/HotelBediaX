using BediaX.Application.Catalog.Dtos;
using BediaX.Application.Catalog.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BediaX.API.Catalog.Controllers;

/// <summary>
/// Provides read-only catalog endpoints (countries and destination types)
/// used by the Destinations module for dropdowns and validations.
/// </summary>
[ApiController]
[Route("api")]
public class CatalogController : ControllerBase
{
    private readonly IMediator _mediator;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="CatalogController"/> class.
    /// </summary>
    /// <param name="mediator">MediatR dispatcher.</param>
    public CatalogController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Gets the full list of available countries.}
    /// </summary>
    /// <remarks>
    /// This endpoint consumed by the front-end to populate a
    /// country select box when creating or editing destinations.
    /// </remarks>
    /// <response code="200">Returns the collection of countries.</response>
    [HttpGet("countries")]
    [SwaggerOperation(
        Summary = "Retrieve countries",
        Description = "Returns all countries used by the Destinations module.")]
    [ProducesResponseType<IReadOnlyList<CountryDto>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCountries(CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetCountriesQuery(), cancellationToken));
    }

    /// <summary>
    /// Gets the list of destination types (Beach, Mountain, etc.).
    /// </summary>
    /// <remarks>
    /// The data is seeded once; types are ordered by <c>Id</c>.
    /// </remarks>
    /// <response code="200">Returns the collection of destination types.</response>
    [HttpGet("destination-types")]
    [SwaggerOperation(
        Summary = "Retrieve destination types",
        Description = "Returns all destination types recognised by the system.")]
    [ProducesResponseType<IReadOnlyList<DestinationTypeDto>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDestinationTypes(CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetDestinationTypesQuery(), cancellationToken));
    }
    
    
}