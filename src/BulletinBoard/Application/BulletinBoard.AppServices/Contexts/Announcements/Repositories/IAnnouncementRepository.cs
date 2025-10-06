using BulletinBoard.Contracts.Announcements.Requests;
using BulletinBoard.Contracts.Announcements.Responses;
using BulletinBoard.Domain.Entities;

namespace BulletinBoard.AppServices.Contexts.Announcements.Repositories;

/// <summary>
///     Репозиторий объявлений.
/// </summary>
public interface IAnnouncementRepository
{
    /// <summary>
    ///     Создает новое объявление.
    /// </summary>
    /// <param name="announcement">Объявление.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Идентификатор созданного объявления.</returns>
    Task<Guid> CreateAsync(Announcement announcement, CancellationToken cancellationToken);

    /// <summary>
    ///     Получает объявления по фильтру.
    /// </summary>
    /// <param name="filter">Фильтр.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Коллекция объявлений.</returns>
    Task<IReadOnlyCollection<AnnouncementResponse>> GetByFilterAsync(AnnouncementFilterRequest filter,
        CancellationToken cancellationToken);

    /// <summary>
    ///     Получает объявление по идентификатору.
    /// </summary>
    /// <param name="announcementId">Идентификатор объявления.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Объявление.</returns>
    Task<AnnouncementResponse> GetByIdAsync(Guid announcementId, CancellationToken cancellationToken);

    /// <summary>
    ///     Обновляет объявление.
    /// </summary>
    /// <param name="announcementId">Идентификатор объявления.</param>
    /// <param name="request">Объявление с новыми данными.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Объявление.</returns>
    Task<AnnouncementResponse> UpdateAsync(Guid announcementId, Announcement request,
        CancellationToken cancellationToken);

    /// <summary>
    ///     Удаляет объявление.
    /// </summary>
    /// <param name="announcementId">Идентификатор объявления.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>True, если объявление успешно удалено, иначе false.</returns>
    Task DeleteAsync(Guid announcementId, CancellationToken cancellationToken);
}