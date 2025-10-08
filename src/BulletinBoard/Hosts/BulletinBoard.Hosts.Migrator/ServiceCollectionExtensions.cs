using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BulletinBoard.Hosts.Migrator;

/// <summary>
/// Расширения для регистрации сервисов в DI-контейнере.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Добавляет сервисы приложения.
    /// </summary>
    /// <param name="services">Севрисы.</param>
    /// <param name="configuration">Конфигурация.</param>
    /// <returns>Коллекция сервисов.</returns>
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureDbConnection(configuration);
        return services;
    }

    /// <summary>
    /// Настраивает подключение к базе данных.
    /// </summary>
    /// <param name="services">Сервисы.</param>
    /// <param name="configuration">Конфигурация.</param>
    /// <returns>Коллекция сервисов.</returns>
    private static IServiceCollection ConfigureDbConnection(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<MigrationDbContext>(options => options.UseNpgsql(connectionString));
        return services;
    }
}