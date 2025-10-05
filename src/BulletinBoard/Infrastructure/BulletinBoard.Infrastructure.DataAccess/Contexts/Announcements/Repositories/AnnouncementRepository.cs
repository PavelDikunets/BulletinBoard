using System.Collections.Concurrent;
using BulletinBoard.AppServices.Contexts.Announcements.Repositories;
using BulletinBoard.Contracts.Announcements.Requests;
using BulletinBoard.Domain.Entities;

namespace BulletinBoard.Infrastructure.DataAccess.Contexts.Announcements.Repositories;

/// <inheritdoc />
public class AnnouncementRepository : IAnnouncementRepository
{
    private readonly ConcurrentDictionary<Guid, Announcement> _announcements = new();

    /// <inheritdoc />
    public Task<IReadOnlyCollection<Announcement>> GetByFilterAsync(AnnouncementFilterRequest filter,
        CancellationToken cancellationToken)
    {
        var announcements = _announcements.Values.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(filter.Title))
            announcements = announcements.Where(a =>
                a.Title.Contains(filter.Title, StringComparison.InvariantCultureIgnoreCase));

        var result = announcements.ToList().AsReadOnly();

        return Task.FromResult<IReadOnlyCollection<Announcement>>(result);
    }

    /// <inheritdoc />
    public Task<Announcement> GetByIdAsync(Guid announcementId, CancellationToken cancellationToken)
    {
        _announcements.TryGetValue(announcementId, out var announcement);

        return Task.FromResult(announcement ?? new Announcement());
    }

    /// <inheritdoc />
    public Task<Announcement> CreateAsync(Announcement newAnnouncement, CancellationToken cancellationToken)
    {
        _announcements.TryAdd(newAnnouncement.Id, newAnnouncement);

        return Task.FromResult(newAnnouncement);
    }

    /// <inheritdoc />
    public Task<Announcement> UpdateAsync(Guid announcementId, Announcement updateAnnouncement,
        CancellationToken cancellationToken)
    {
        if (!_announcements.TryGetValue(announcementId, out var existingAnnouncement))
            return Task.FromResult(new Announcement());

        updateAnnouncement.Title = existingAnnouncement.Title;
        updateAnnouncement.Description = existingAnnouncement.Description;

        _announcements.TryUpdate(announcementId, updateAnnouncement, existingAnnouncement);

        return Task.FromResult(updateAnnouncement);
    }

    /// <inheritdoc />
    public Task<bool> DeleteAsync(Guid announcementId, CancellationToken cancellationToken)
    {
        var result = _announcements.TryRemove(announcementId, out _);

        return Task.FromResult(result);
    }
}