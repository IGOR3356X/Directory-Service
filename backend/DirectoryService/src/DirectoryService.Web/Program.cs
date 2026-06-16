using DirectoryService.Core.Location;
using DirectoryService.Infrastructure.Postgres;
using DirectoryService.Infrastructure.Postgres.Location;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionString"));
});
builder.Services.AddValidatorsFromAssemblyContaining<CreateLocationValidator>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();

builder.Services.AddControllers();

builder.Services.AddHealthChecks();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapHealthChecks("/health");

app.MapControllers();

if (!app.Environment.IsProduction())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

await app.RunAsync();
