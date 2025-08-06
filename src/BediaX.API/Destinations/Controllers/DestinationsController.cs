using BediaX.API.Destinations.Dtos;
using BediaX.Application.Destinations.Commands;
using BediaX.Application.Destinations.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BediaX.API.Destinations.Controllers;

/// <summary>
/// CRUD endpoints for <c>Destinations</c>
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class DestinationsController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="DestinationsController"/> class.
    /// </summary>
    /// <param name="mediator">MediatR dispatcher.</param>
    public DestinationsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <summary>
    /// Returns a paginated list of destinations.
    /// </summary>
    /// <remarks>
    /// Optional <c>filter</c> parameter performs a <c>contains</c> match on the destination <c>Name</c>.
    /// </remarks>
    /// <param name="page">Page number (1-based).</param>
    /// <param name="pageSize">Number of records per page (default = 20).</param>
    /// <param name="filter">Text to search for inside the destination name. Pass <see langword="null"/> or empty to disable filtering.</param>
    /// <param name="cancellationToken">Cancellation token propagated from the HTTP request.</param>
    /// <returns>A <see cref="GetDestinationsResponse"/> object containing paging metadata and the requested page of destinations.</returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "List destinations (paginated)",
        Description = "Returns paging metadata plus the requested page of destinations.")]
    [ProducesResponseType<GetDestinationsResponse>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPaged([FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] string? filter = null, CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(new GetDestinationsDtoPagedQuery(page, pageSize, filter), cancellationToken);

        var totalPages = (int)Math.Ceiling(result.Total / (double)pageSize);

        var dto = new GetDestinationsResponse(page, pageSize, result.Total, totalPages, page < totalPages, page > 1, result.Items);

        return Ok(dto);
    }
    
    /// <summary> 
    /// Retrieves a destination by its identifier.
    /// </summary>
    /// <param name="id">Destination identifier.</param>
    /// <param name="cancellationToken">Cancellation token propagated from the HTTP request.</param>
    /// <returns>
    /// A <see cref="GetDestinationByIdResponse"/> when the destination exists; otherwise <c>404 Not Found</c>.
    /// </returns>
    [HttpGet("{id:int}")]
    [SwaggerOperation(Summary = "Destination details")]
    [ProducesResponseType<GetDestinationByIdResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var dto = await _mediator.Send(new GetDestinationDtoByIdQuery(id), cancellationToken);
        if (dto is null)
        {
            return NotFound();
        }
        
        return Ok(dto);
    }

    /// <summary>
    /// Creates a new destination with the provided details.
    /// </summary>
    /// <param name="request">Payload containing name, description, country, and destination type.</param>
    /// <param name="cancellationToken">Cancellation token propagated from the HTTP request.</param>
    /// <returns>
    /// <c>201 Created</c> with the generated identifier when successful, or 
    /// <c>400 Bad Request</c> when validation fails.
    /// </returns>
    [HttpPost]
    [SwaggerOperation(Summary = "Create destination")]
    [ProducesResponseType<int>(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateDestinationRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateDestinationCommand(
            request.Name,
            request.Description,
            request.CountryId,
            request.DestinationTypeId);

        var id = await _mediator.Send(command, cancellationToken);

        return CreatedAtAction(nameof(Create), new { id }, id);
    }
    
    /// <summary>
    /// Updates an existing destination.
    /// </summary>
    /// <param name="id">Identifier of the destination to update.</param>
    /// <param name="request">Payload with the new name, description, country, destination type, and active flag.</param>
    /// <param name="cancellationToken">Cancellation token propagated from the HTTP request.</param>
    /// <returns>
    /// <c>204 No Content</c> when the update succeeds, 
    /// <c>404 Not Found</c> when the destination does not exist, or 
    /// <c>400 Bad Request</c> when validation fails.
    /// </returns>
    [HttpPut("{id:int}")]
    [SwaggerOperation(Summary = "Update destination")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateDestinationRequest request, CancellationToken cancellationToken)
    {
        var command = new UpdateDestinationCommand(
            id,
            request.Name,
            request.Description,
            request.CountryId,
            request.DestinationTypeId,
            request.IsActive);

        var updated = await _mediator.Send(command, cancellationToken);
        return updated ? NoContent() : NotFound();
    }
    /// <summary>
    /// Soft-deletes a destination by its identifier.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("{id:int}")]
    [SwaggerOperation(Summary = "Delete destination (soft)")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await _mediator.Send(new DeleteDestinationCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}