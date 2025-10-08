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
    Task<IReadOnlyCollection<Announcement>> GetByFilterAsync(AnnouncementFilterRequest filter,
        CancellationToken cancellationToken);

    /// <summary>
    ///     Получает объявление по идентификатору.
    /// </summary>
    /// <param name="announcementId">Идентификатор объявления.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Объявление.</returns>
    Task<Announcement?> GetByIdAsync(Guid announcementId, CancellationToken cancellationToken);

    /// <summary>
    ///     Обновляет объявление.
    /// </summary>
    /// <param name="announcement">Объявление с новыми данными.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Объявление.</returns>
    Task<Announcement> UpdateAsync(Announcement announcement,
        CancellationToken cancellationToken);

    /// <summary>
    ///     Удаляет объявление.
    /// </summary>
    /// <param name="announcementId">Идентификатор объявления.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>True, если объявление успешно удалено, иначе false.</returns>
    Task DeleteAsync(Guid announcementId, CancellationToken cancellationToken);

    /// <summary>
    /// Проверяет существование объявления.
    /// </summary>
    /// <param name="announcementId">Идентификатор объявления</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>True - объявление существует, в противном случае - false.</returns>
    Task<bool> ExistsAsync(Guid announcementId, CancellationToken cancellationToken);
}