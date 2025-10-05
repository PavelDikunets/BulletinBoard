using BulletinBoard.AppServices.Contexts.Announcements.Repositories;
using BulletinBoard.Contracts.Announcements.Requests;
using BulletinBoard.Contracts.Announcements.Responses;
using BulletinBoard.Domain.Entities;

namespace BulletinBoard.AppServices.Contexts.Announcements.Services;

/// <inheritdoc />
public class AnnouncementService : IAnnouncementService
{
    private readonly IAnnouncementRepository _announcementRepository;

    /// <summary>
    ///     Инициализирует экземпляр <see cref="AnnouncementService" />.
    /// </summary>
    /// <param name="announcementRepository">Репозиторий объявлений.</param>
    public AnnouncementService(IAnnouncementRepository announcementRepository)
    {
        _announcementRepository = announcementRepository;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<AnnouncementResponse>> GetByFilterAsync(AnnouncementFilterRequest filter,
        CancellationToken cancellationToken)
    {
        var announcements = await _announcementRepository.GetByFilterAsync(filter, cancellationToken);

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
        var announcement = await _announcementRepository.GetByIdAsync(announcementId, cancellationToken);

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
    public async Task<AnnouncementResponse> CreateAsync(CreateAnnouncementRequest announcementRequest,
        CancellationToken cancellationToken)
    {
        var announcement = new Announcement
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            Title = announcementRequest.Title,
            Description = announcementRequest.Description
        };

        var result = await _announcementRepository.CreateAsync(announcement, cancellationToken);

        var response = new AnnouncementResponse
        {
            Id = result.Id,
            Title = result.Title,
            Description = result.Description,
            CreatedAt = result.CreatedAt
        };

        return response;
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
            await _announcementRepository.UpdateAsync(announcementId, announcement, cancellationToken);

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
    public async Task<bool> DeleteAsync(Guid announcementId, CancellationToken cancellationToken)
    {
        return await _announcementRepository.DeleteAsync(announcementId, cancellationToken);
    }
}