using DirectoryService.Domain;
using DirectoryService.Infrastructure.Postgres.Database;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public TestController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { message = "TestController works!", time = DateTimeOffset.UtcNow });
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        return Ok(new { id, message = $"Item {id} found" });
    }

    [HttpPost]
    public async Task<IActionResult> CreateGg()
    {
        var dep = Domain.Department.Create("Test", "main", null, null, true);
        await _dbContext.Departments.AddAsync(dep);
        await _dbContext.SaveChangesAsync();

        return Ok(new { dep });
    }
}