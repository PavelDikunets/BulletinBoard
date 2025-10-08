using AutoMapper;
using BulletinBoard.AppServices.Contexts.Announcements.Repositories;
using BulletinBoard.AppServices.Exceptions;
using BulletinBoard.Contracts.Announcements.Requests;
using BulletinBoard.Contracts.Announcements.Responses;
using BulletinBoard.Domain.Entities;

namespace BulletinBoard.AppServices.Contexts.Announcements.Services;

/// <inheritdoc />
public class AnnouncementService(
    IAnnouncementRepository announcementRepository,
    IMapper mapper
) : IAnnouncementService
{
    /// <inheritdoc />
    public async Task<IReadOnlyCollection<AnnouncementResponse>> GetByFilterAsync(AnnouncementFilterRequest filter,
        CancellationToken cancellationToken)
    {
        var announcements = await announcementRepository.GetByFilterAsync(filter, cancellationToken);
        return mapper.Map<IReadOnlyCollection<AnnouncementResponse>>(announcements);
    }

    /// <inheritdoc />
    public async Task<AnnouncementResponse> GetByIdAsync(Guid announcementId, CancellationToken cancellationToken)
    {
        var announcement = await GetAnnouncementOrThrowAsync(announcementId, cancellationToken);
        return mapper.Map<AnnouncementResponse>(announcement);
    }

    /// <inheritdoc />
    public async Task<Guid> CreateAsync(CreateAnnouncementRequest request,
        CancellationToken cancellationToken)
    {
        var announcement = mapper.Map<CreateAnnouncementRequest, Announcement>(request);
        announcement.CreatedAt = DateTime.UtcNow;
        return await announcementRepository.CreateAsync(announcement, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<AnnouncementResponse> UpdateAsync(Guid announcementId, UpdateAnnouncementRequest request, CancellationToken cancellationToken)
    {
        var announcement = await GetAnnouncementOrThrowAsync(announcementId, cancellationToken);
        mapper.Map(request, announcement);
        await announcementRepository.UpdateAsync(announcement, cancellationToken);
        return mapper.Map<AnnouncementResponse>(announcement);
    }
    
    /// <inheritdoc />
    public async Task DeleteAsync(Guid announcementId, CancellationToken cancellationToken)
    {
        var exists = await announcementRepository.ExistsAsync(announcementId, cancellationToken);
        if (!exists) throw new NotFoundException(announcementId.ToString());
        await announcementRepository.DeleteAsync(announcementId, cancellationToken);
    }
    
    
    
    private async Task<Announcement> GetAnnouncementOrThrowAsync(Guid announcementId, CancellationToken cancellationToken)
    {
        var announcement = await announcementRepository.GetByIdAsync(announcementId, cancellationToken);
        return announcement ?? throw new NotFoundException(announcementId.ToString());
    }
}