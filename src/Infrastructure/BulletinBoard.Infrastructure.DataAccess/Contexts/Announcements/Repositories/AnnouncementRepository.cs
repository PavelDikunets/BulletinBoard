using BulletinBoard.AppServices.Contexts.Announcements.Repositories;
using BulletinBoard.Contracts.Announcements.Requests;
using BulletinBoard.Domain.Entities;
using BulletinBoard.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BulletinBoard.Infrastructure.DataAccess.Contexts.Announcements.Repositories;

/// <inheritdoc />
public class AnnouncementRepository(
    IBaseRepository<Announcement, ApplicationDbContext> repository
) : IAnnouncementRepository
{
    /// <inheritdoc />
    public async Task<Guid> CreateAsync(Announcement announcement, CancellationToken cancellationToken)
    {
        await repository.AddAsync(announcement, cancellationToken);
        return announcement.Id;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<Announcement>> GetByFilterAsync(AnnouncementFilterRequest filter,
        CancellationToken cancellationToken)
    {
        var query = repository.GetAll().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(filter.Title))
            query = query.Where(a => a.Title.Contains(filter.Title));

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<Announcement?> GetByIdAsync(Guid announcementId, CancellationToken cancellationToken)
    {
        return await repository.GetByIdAsync(announcementId, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<Announcement> UpdateAsync(Announcement announcement, CancellationToken cancellationToken)
    {
        await repository.UpdateAsync(announcement, cancellationToken);
        return announcement;
    }

    /// <inheritdoc />
    public async Task DeleteAsync(Guid announcementId, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(announcementId, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<bool> ExistsAsync(Guid announcementId, CancellationToken cancellationToken)
    {
        return await repository.GetAll().AnyAsync(x => x.Id == announcementId, cancellationToken);
    }
}