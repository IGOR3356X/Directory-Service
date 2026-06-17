using DirectoryService.Core.Location;
using DirectoryService.Infrastructure.Postgres.Database;
using DirectoryService.Infrastructure.Postgres.Location;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddSingleton<INpgsqlConnectionFactory, NpgsqlConnectionFactory>();
builder.Services.AddDbContext<AppDbContext>((sp, options) =>
{
    var connectionString = builder.Configuration.GetConnectionString("ConnectionString")
                           ?? throw new InvalidOperationException("Connection string 'ConnectionString' not found.");

    options.UseNpgsql(connectionString);

    if (builder.Environment.IsDevelopment())
        options
            .UseLoggerFactory(sp.GetRequiredService<ILoggerFactory>())
            .EnableDetailedErrors()
            .EnableSensitiveDataLogging();
});
builder.Services.AddValidatorsFromAssemblyContaining<CreateLocationValidator>();
builder.Services.AddScoped<ILocationService, LocationService>();
// builder.Services.AddScoped<ILocationRepository, LocationRepository>();

builder.Services.AddScoped<ILocationRepository, LocationRepositorySql>();

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