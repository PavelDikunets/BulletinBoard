using BulletinBoard.AppServices.Contexts.Announcements.Repositories;
using BulletinBoard.AppServices.Exceptions;
using BulletinBoard.Contracts.Announcements.Requests;
using BulletinBoard.Contracts.Announcements.Responses;
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
    public async Task<IReadOnlyCollection<AnnouncementResponse>> GetByFilterAsync(AnnouncementFilterRequest filter,
        CancellationToken cancellationToken)
    {
        var announcements = repository.GetAll();

        if (!string.IsNullOrWhiteSpace(filter.Title))
            announcements = announcements.Where(a =>
                a.Title.Contains(filter.Title, StringComparison.InvariantCultureIgnoreCase));

        var response = await announcements
            .Select(a => new AnnouncementResponse
            {
                Id = a.Id,
                Title = a.Title,
                Description = a.Description,
                CreatedAt = a.CreatedAt
            })
            .ToListAsync(cancellationToken);
        return response;
    }

    public async Task<AnnouncementResponse> GetByIdAsync(Guid announcementId, CancellationToken cancellationToken)
    {
        var announcement = await repository.GetByIdAsync(announcementId, cancellationToken);

        if (announcement == null) throw new NotFoundException(announcementId.ToString());

        var response = new AnnouncementResponse
        {
            Id = announcement.Id,
            Title = announcement.Title,
            Description = announcement.Description,
            CreatedAt = announcement.CreatedAt
        };
        return response;
    }

    /// <inheritdoc />
    public async Task<AnnouncementResponse> UpdateAsync(Guid announcementId, Announcement request,
        CancellationToken cancellationToken)
    {
        var announcement = await repository.GetByIdAsync(announcementId, cancellationToken);

        if (announcement is null) throw new NotFoundException(announcementId.ToString());

        announcement.Title = request.Title;
        announcement.Description = request.Description;

        await repository.UpdateAsync(announcement, cancellationToken);

        return await GetByIdAsync(announcementId, cancellationToken) ??
               throw new NotFoundException(announcementId.ToString());
    }

    /// <inheritdoc />
    public async Task DeleteAsync(Guid announcementId, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(announcementId, cancellationToken);
    }
}