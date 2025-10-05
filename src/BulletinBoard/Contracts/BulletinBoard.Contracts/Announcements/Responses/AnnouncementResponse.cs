namespace BulletinBoard.Contracts.Announcements.Responses;

/// <summary>
///     Модель объявления.
/// </summary>
public class AnnouncementResponse
{
    /// <summary>
    ///     Идентификатор.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    ///     Заголовок.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    ///     Описание.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    ///     Дата создания.
    /// </summary>
    public DateTime CreatedAt { get; set; }
}