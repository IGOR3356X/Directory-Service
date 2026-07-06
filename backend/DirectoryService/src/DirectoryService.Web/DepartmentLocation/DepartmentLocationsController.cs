using DirectoryService.Contracts;
using DirectoryService.Core.DepartmentLocation;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Web.DepartmentLocation;

[ApiController]
[Route("departments")]
[Produces("application/json")]
public class DepartmentLocationsController : ControllerBase
{
    private readonly IDepartmentLocationService _departmentLocationService;

    public DepartmentLocationsController(IDepartmentLocationService departmentLocationService)
    {
        _departmentLocationService = departmentLocationService;
    }

    [HttpPost("{departmentId:guid}/locations/{locationId:guid}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreateDepartmentLink(
        [FromRoute] Guid departmentId,
        [FromRoute] Guid locationId,
        [FromBody] bool isPrimary,
        CancellationToken ct)
    {
        var linkId = await _departmentLocationService.CreateLink(departmentId, locationId, isPrimary, ct);
        var entity = new CreatedDepartmentLocationDto(linkId, departmentId, locationId, isPrimary);
        return CreatedAtAction(nameof(GetDepartmentLocation), new { departmentLocationId = linkId }, entity);
    }
    
    [HttpDelete("{departmentId:guid}/locations/{locationId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteDepartmentLink(
        [FromRoute] Guid departmentId,
        [FromRoute] Guid locationId,
        CancellationToken ct)
    {
        await _departmentLocationService.DeleteLink(departmentId, locationId, ct);
        return NoContent();
    }

    [HttpGet("department_locations/{departmentLocationId:guid}")]
    [ProducesResponseType(typeof(DepartmentLocationDto),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetDepartmentLocation(
        [FromRoute] Guid departmentLocationId,
        CancellationToken ct)
    {
        return NotFound();
    }
}
