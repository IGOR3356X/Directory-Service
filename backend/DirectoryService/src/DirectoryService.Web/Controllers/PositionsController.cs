using DirectoryService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Web.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class PositionController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<PositionDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(CancellationToken ct)
    {
        return Ok(Array.Empty<PositionDto>());
    }

    [HttpGet("{positionId:guid}")]
    [ProducesResponseType(typeof(PositionDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById([FromRoute] Guid positionId, CancellationToken ct)
    {
        return NotFound();
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreatedPositionDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreatePositionDto dto, CancellationToken ct)
    {
        var id = Guid.CreateVersion7();
        var entity = new CreatedPositionDto(
            id,
            dto.Name,
            dto.Description,
            dto.IsActive);
        return CreatedAtAction(nameof(GetById), new { positionId = id }, entity);
    }

    [HttpPut("{positionId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update([FromRoute] Guid positionId, [FromBody] UpdatePositionDto request,
        CancellationToken ct)
    {
        return NoContent();
    }

    [HttpDelete("{positionId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] Guid positionId, CancellationToken ct)
    {
        return NoContent();
    }
}