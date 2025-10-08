using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BulletinBoard.Hosts.Migrator;

/// <summary>
/// Фабрика контекста базы данных.
/// </summary>
public class MigrationDbContextFactory : IDesignTimeDbContextFactory<MigrationDbContext>
{
    /// <summary>
    /// Создает контекст базы данных.
    /// </summary>
    /// <returns>Экземпляр контекста базы данных, настроенного для подключения к PostgreSQL.</returns>
    public MigrationDbContext CreateDbContext(string[] args)
    {
        var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
        var configuration = builder.Build();
        var connectionString = configuration.GetConnectionString("ConnectionString");

        var contextBuilder = new DbContextOptionsBuilder<MigrationDbContext>();
        contextBuilder.UseNpgsql(connectionString);
        return new MigrationDbContext(contextBuilder.Options);
    }
}