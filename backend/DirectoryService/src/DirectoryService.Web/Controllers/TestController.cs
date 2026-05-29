using DirectoryService.Domain;
using DirectoryService.Infrastructure.Postgres;
using Microsoft.AspNetCore.Mvc;
using Path = DirectoryService.Domain.Path;

namespace DirectoryService.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly AppDbContext dbContext;
    public TestController(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpGet]
    public IActionResult Get() =>
        Ok(new { message = "TestController works!", time = DateTimeOffset.UtcNow });

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id) =>
        Ok(new { id, message = $"Item {id} found" });

    [HttpPost]
    public async Task<IActionResult> CreateGg()
    {
        var dep = Department.Create("Test", "main", null, null,true);
        await dbContext.Departments.AddAsync(dep);
        await dbContext.SaveChangesAsync();

        return Ok(new { dep });
    }
}