using DirectoryService.Contracts;
using DirectoryService.Core.Location;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Web.Controllers;
[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class LocationController: ControllerBase
{
    private readonly ILocationService _locationService;


    public LocationController(ILocationService locationService)
    {
        _locationService = locationService;
    }
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<LocationDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(CancellationToken ct)
    {
        return Ok(Array.Empty<LocationDto>());
    }

    [HttpGet("{locationId:guid}")]
    [ProducesResponseType(typeof(LocationDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById([FromRoute] Guid locationId, CancellationToken ct)
    {
        return NotFound();
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreatedLocationDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateLocationDto request,CancellationToken ct)
    {
        var locationId = _locationService.Create(request, ct);
        return CreatedAtAction(nameof(GetById), new { locationId = locationId });
    }

    [HttpPut("{locationId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update([FromRoute] Guid locationId, [FromBody] UpdateLocationDto request, CancellationToken ct)
    {
        return NoContent();
    }

    [HttpDelete("{locationId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] Guid locationId, CancellationToken ct)
    {
        return NoContent();
    }
}