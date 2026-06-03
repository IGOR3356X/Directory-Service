using DirectoryService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Web.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class DepartmentController: ControllerBase
{
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
        var id = Guid.CreateVersion7();
        var entity = new CreatedDepartmentDto(
            id,
            dto.Name,
            dto.Slug,
            dto.ParentId ?? Guid.Empty,
            dto.ParentPath,
            dto.IsActive);
        return CreatedAtAction(nameof(GetById), new { departmentId = id }, entity);
    }

    [HttpPut("{departmentId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update([FromRoute] Guid departmentId, [FromBody] UpdateDepartmentDto request, CancellationToken ct)
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