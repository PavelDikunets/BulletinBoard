using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BulletinBoard.Hosts.Migrator;

/// <summary>
/// Точка входа мигратора для применения миграций.
/// </summary>
public static class Program
{
    public static async Task Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args).ConfigureServices((hostContext, services) =>
        {
            services.AddServices(hostContext.Configuration);
        }).Build();

        await MigrateDatabaseAsync(host.Services);
    }

    private static async Task MigrateDatabaseAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<MigrationDbContext>();
        await context.Database.EnsureCreatedAsync();
    }
}