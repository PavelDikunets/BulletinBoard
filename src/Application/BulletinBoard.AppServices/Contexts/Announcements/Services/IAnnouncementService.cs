using BulletinBoard.Contracts.Announcements.Requests;
using BulletinBoard.Contracts.Announcements.Responses;

namespace BulletinBoard.AppServices.Contexts.Announcements.Services;

/// <summary>
///     Сервис для работы с объявлениями.
/// </summary>
public interface IAnnouncementService
{
    /// <summary>
    ///     Получает объявления по фильтру.
    /// </summary>
    /// <param name="filter">Фильтр.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Коллекция объявлений.</returns>
    Task<IReadOnlyCollection<AnnouncementShortResponse>> GetByFilterAsync(AnnouncementFilterRequest filter,
        CancellationToken cancellationToken);

    /// <summary>
    ///     Получает объявление по идентификатору.
    /// </summary>
    /// <param name="announcementId">Идентификатор объявления.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Модель объявления.</returns>
    Task<AnnouncementResponse> GetByIdAsync(Guid announcementId, CancellationToken cancellationToken);

    /// <summary>
    ///     Создает новое объявление.
    /// </summary>
    /// <param name="announcementRequest">Модель создания объявления.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Идентификатор созданного объявления.</returns>
    Task<Guid> CreateAsync(CreateAnnouncementRequest announcementRequest, CancellationToken cancellationToken);

    /// <summary>
    ///     Обновляет объявление.
    /// </summary>
    /// <param name="announcementId">Идентификатор объявления.</param>
    /// <param name="announcementRequest">Модель обновления объявления.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Модель объявления.</returns>
    Task<AnnouncementResponse> UpdateAsync(Guid announcementId, UpdateAnnouncementRequest announcementRequest,
        CancellationToken cancellationToken);

    /// <summary>
    ///     Удаляет объявление.
    /// </summary>
    /// <param name="announcementId">Идентификатор объявления.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>True, если объявление успешно удалено, иначе false.</returns>
    Task DeleteAsync(Guid announcementId, CancellationToken cancellationToken);
}