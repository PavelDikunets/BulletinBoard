using BulletinBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BulletinBoard.Infrastructure.DataAccess.Contexts.Announcements.Configurations;

/// <summary>
///     Конфигурация сущности объявления.
/// </summary>
public class AnnouncementConfiguration : IEntityTypeConfiguration<Announcement>
{
    /// <summary>
    ///     Настраивает модель сущности объявления.
    /// </summary>
    /// <param name="builder">Строитель конфигурации сущности.</param>
    public void Configure(EntityTypeBuilder<Announcement> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Title).HasMaxLength(64).IsRequired();
        builder.Property(x => x.Image).HasMaxLength(512).IsRequired(false);
        builder.Property(x => x.Description).HasMaxLength(1024).IsRequired();
        builder.Property(x => x.Complectation).HasMaxLength(1024).IsRequired(false);
        builder.Property(x => x.Price).HasPrecision(18, 2).IsRequired();
        builder.Property(x => x.Condition).IsRequired();
        builder.Property(x => x.UpdatedAt).IsRequired();

        builder.HasIndex(a => new { a.CreatedAt, a.Id }).IsUnique();
    }
}