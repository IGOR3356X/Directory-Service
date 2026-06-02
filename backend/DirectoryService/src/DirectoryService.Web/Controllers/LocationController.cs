using DirectoryService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Web.Controllers;
[ApiController]
[Route("[controller]")]
public class LocationController: ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken ct)
    {
        return Ok(new { Get = "Get"});
    }

    [HttpGet("{locationId:guid}")]
    public async Task<IActionResult> GetById(Guid locationId, CancellationToken ct)
    {
        return Ok(new { Get = "GetById"});
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateLocationDto request,CancellationToken ct)
    {
       var newEntity = new CreatedLocationDto(Guid.CreateVersion7(),request.Name, request.City, request.Street,request.HouseNumber, request.IsActive);
        return CreatedAtAction(nameof(GetById),new {id =  newEntity.Id}, newEntity);
    }

    [HttpPut("{locationId:guid}")]
    public async Task<IActionResult> Update([FromBody] UpdateLocationDto request, CancellationToken ct)
    {
        return NoContent();
    }

    [HttpDelete("{locationId:guid}")]
    public async Task<IActionResult> Delete(Guid locationId, CancellationToken ct)
    {
        return NoContent();
    }
}