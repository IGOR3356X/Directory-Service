using DirectoryService.Contracts;
using DirectoryService.Core.Department;
using DirectoryService.Core.Location;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Web.Department;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class DepartmentsController : ControllerBase
{
    private readonly IDepartmentService _locationService;
    public DepartmentsController(IDepartmentService locationService)
    {
        _locationService = locationService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<DepartmentDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(CancellationToken ct)
    {
        return Ok(Array.Empty<DepartmentDto>());
    }

    [HttpGet("{departmentId:guid}")]
    [ProducesResponseType(typeof(DepartmentDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById([FromRoute] Guid departmentId, CancellationToken ct)
    {
        return NotFound();
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreatedDepartmentDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateDepartmentDto dto, CancellationToken ct)
    {
        var departmentId = await _locationService.Create(dto, ct);
        var entity = new CreatedDepartmentDto(
            departmentId,
            dto.Name,
            dto.Slug,
            dto.ParentId,
            dto.LocationIds,
            dto.IsActive
        );
        return CreatedAtAction(nameof(GetById), new { departmentId = departmentId }, entity);
    }

    [HttpPut("{departmentId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update([FromRoute] Guid departmentId, [FromBody] UpdateDepartmentDto request,
        CancellationToken ct)
    {
        return NoContent();
    }

    [HttpDelete("{departmentId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] Guid departmentId, CancellationToken ct)
    {
        return NoContent();
    }
}