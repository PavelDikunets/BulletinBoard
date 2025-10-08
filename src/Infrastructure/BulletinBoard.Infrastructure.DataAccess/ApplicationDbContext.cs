using BulletinBoard.Domain.Entities;
using BulletinBoard.Infrastructure.DataAccess.Contexts.Announcements.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BulletinBoard.Infrastructure.DataAccess;

/// <summary>
///     Основной контекст базы данных всего приложения.
/// </summary>
public class ApplicationDbContext : DbContext
{
    /// <summary>
    ///     Инициализирует новый экземпляр <see cref="ApplicationDbContext" /> с заданными опциями.
    /// </summary>
    /// <param name="options">Опции конфигурации.</param>
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    /// <summary>
    ///     Набор сущностей объявлений.
    /// </summary>
    public DbSet<Announcement> Announcements { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new AnnouncementConfiguration());
    }
}