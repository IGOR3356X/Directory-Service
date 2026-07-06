using Dapper;
using DirectoryService.Core.Location;
using DirectoryService.Domain.ValueObjects;
using DirectoryService.Infrastructure.Postgres.Database;

namespace DirectoryService.Infrastructure.Postgres.Location;

public sealed class LocationRepositorySql : ILocationRepository
{
    private readonly INpgsqlConnectionFactory _connectionFactory;

    public LocationRepositorySql(INpgsqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<Guid> Create(Domain.Location request, CancellationToken ct)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();

        using var transaction = connection.BeginTransaction();

        try
        {
            const string locationInsertSql = """
                                             INSERT INTO location (id,name,is_active,created_at,updated_at,address_city,address_street,address_house_number)
                                             VALUES (@Id,@Name,@IsActive,@CreatedAt,@UpdatedAt,@AddressCity,@AddressStreet,@AddressHouseNumber)
                                             """;

            var InsertSqlParameters = new
            {
                request.Id,
                Name = request.Name.Value,
                request.IsActive,
                request.CreatedAt,
                request.UpdatedAt,
                AddressCity = request.Address.City,
                AddressStreet = request.Address.Street,
                AddressHouseNumber = request.Address.HouseNumber
            };

            await connection.ExecuteAsync(new CommandDefinition(
                locationInsertSql,
                InsertSqlParameters,
                transaction,
                cancellationToken: ct));

            transaction.Commit();

            return request.Id;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }
    
    public async Task<bool> IsNameExists(string name, CancellationToken ct)
    {
        var target = Name.Create(name);

        const string sql = """
                           SELECT EXISTS (
                               SELECT 1
                               FROM location
                               WHERE name = @name
                           )
                           """;

        using var connection = await _connectionFactory.CreateConnectionAsync();


        return await connection.ExecuteScalarAsync<bool>(
            new CommandDefinition(
                sql,
                new { name = target.Value },
                cancellationToken: ct));
    }

    public async Task<bool> IsLocationExists(IEnumerable<Guid> ids, CancellationToken ct)
    {
        throw new KeyNotFoundException("ЭТОТ МЕТОД НЕ РЕаЛИЗОВАН");
    }

    public Task Save(CancellationToken ct)
    {
        throw new KeyNotFoundException("ЭТОТ МЕТОД НЕ РЕаЛИЗОВАН");
    }
    
    public Task<Domain.Location?> GetById(Guid requestId, CancellationToken ct)
    {
        throw new KeyNotFoundException("ЭТОТ МЕТОД НЕ РЕаЛИЗОВАН");
    }
}