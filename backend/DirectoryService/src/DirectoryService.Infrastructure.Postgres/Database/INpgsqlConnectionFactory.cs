using System.Data;

namespace DirectoryService.Infrastructure.Postgres.Database;

public interface INpgsqlConnectionFactory
{
    public Task<IDbConnection> CreateConnectionAsync();
}