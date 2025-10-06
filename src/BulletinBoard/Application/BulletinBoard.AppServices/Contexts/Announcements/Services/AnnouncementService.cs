using BulletinBoard.AppServices.Contexts.Announcements.Repositories;
using BulletinBoard.Contracts.Announcements.Requests;
using BulletinBoard.Contracts.Announcements.Responses;
using BulletinBoard.Domain.Entities;

namespace BulletinBoard.AppServices.Contexts.Announcements.Services;

/// <inheritdoc />
public class AnnouncementService(
    IAnnouncementRepository announcementRepository
) : IAnnouncementService
{
    /// <inheritdoc />
    public async Task<IReadOnlyCollection<AnnouncementResponse>> GetByFilterAsync(AnnouncementFilterRequest filter,
        CancellationToken cancellationToken)
    {
        var announcements = await announcementRepository.GetByFilterAsync(filter, cancellationToken);

        var response = announcements.Select(announcement => new AnnouncementResponse
        {
            Id = announcement.Id,
            Title = announcement.Title,
            Description = announcement.Description,
            CreatedAt = announcement.CreatedAt
        }).ToList().AsReadOnly();

        return response;
    }

    /// <inheritdoc />
    public async Task<AnnouncementResponse> GetByIdAsync(Guid announcementId, CancellationToken cancellationToken)
    {
        var announcement = await announcementRepository.GetByIdAsync(announcementId, cancellationToken);

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
    public async Task<Guid> CreateAsync(CreateAnnouncementRequest announcementRequest,
        CancellationToken cancellationToken)
    {
        var announcement = new Announcement
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            Title = announcementRequest.Title,
            Description = announcementRequest.Description
        };

        var result = await announcementRepository.CreateAsync(announcement, cancellationToken);

        return result;
    }

    /// <inheritdoc />
    public async Task<AnnouncementResponse> UpdateAsync(Guid announcementId,
        UpdateAnnouncementRequest announcementRequest, CancellationToken cancellationToken)
    {
        var announcement = new Announcement
        {
            Id = announcementId,
            Title = announcementRequest.Title,
            Description = announcementRequest.Description
        };

        var updatedAnnouncement =
            await announcementRepository.UpdateAsync(announcementId, announcement, cancellationToken);

        var response = new AnnouncementResponse
        {
            Id = updatedAnnouncement.Id,
            Title = updatedAnnouncement.Title,
            Description = updatedAnnouncement.Description,
            CreatedAt = updatedAnnouncement.CreatedAt
        };

        return response;
    }

    /// <inheritdoc />
    public async Task DeleteAsync(Guid announcementId, CancellationToken cancellationToken)
    {
        await announcementRepository.DeleteAsync(announcementId, cancellationToken);
    }
}