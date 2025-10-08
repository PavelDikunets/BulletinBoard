using BulletinBoard.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace BulletinBoard.Hosts.Migrator;

/// <summary>
/// Контекст базы данных для мигратора.
/// </summary>
public class MigrationDbContext : ApplicationDbContext
{
    public MigrationDbContext(DbContextOptions options) : base(options)
    {
    }
}