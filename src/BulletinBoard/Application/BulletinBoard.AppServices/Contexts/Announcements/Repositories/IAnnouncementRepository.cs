using BulletinBoard.Contracts.Announcements.Requests;
using BulletinBoard.Domain.Entities;

namespace BulletinBoard.AppServices.Contexts.Announcements.Repositories;

/// <summary>
///     Репозиторий объявлений.
/// </summary>
public interface IAnnouncementRepository
{
    /// <summary>
    ///     Получает объявления по фильтру.
    /// </summary>
    /// <param name="filter">Фильтр.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Коллекция объявлений.</returns>
    Task<IReadOnlyCollection<Announcement>> GetByFilterAsync(AnnouncementFilterRequest filter,
        CancellationToken cancellationToken);

    /// <summary>
    ///     Получает объявление по идентификатору.
    /// </summary>
    /// <param name="announcementId">Идентификатор объявления.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Объявление.</returns>
    Task<Announcement> GetByIdAsync(Guid announcementId, CancellationToken cancellationToken);

    /// <summary>
    ///     Создает новое объявление.
    /// </summary>
    /// <param name="newAnnouncement">Новое объявление.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Объявление.</returns>
    Task<Announcement> CreateAsync(Announcement newAnnouncement, CancellationToken cancellationToken);

    /// <summary>
    ///     Обновляет объявление.
    /// </summary>
    /// <param name="announcementId">Идентификатор объявления.</param>
    /// <param name="updateAnnouncement">Обновленное объявление.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Объявление.</returns>
    Task<Announcement> UpdateAsync(Guid announcementId, Announcement updateAnnouncement,
        CancellationToken cancellationToken);

    /// <summary>
    ///     Удаляет объявление.
    /// </summary>
    /// <param name="announcementId">Идентификатор объявления.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>True, если объявление успешно удалено, иначе false.</returns>
    Task<bool> DeleteAsync(Guid announcementId, CancellationToken cancellationToken);
}