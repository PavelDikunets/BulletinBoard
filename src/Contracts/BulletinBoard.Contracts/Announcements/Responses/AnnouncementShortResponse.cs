namespace BulletinBoard.Contracts.Announcements.Responses;

/// <summary>
///     Краткая модель объявления.
/// </summary>
public class AnnouncementShortResponse
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
    ///     Цена.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    ///     Изображение.
    /// </summary>
    public string? Image { get; set; }

    /// <summary>
    ///     Дата создания.
    /// </summary>
    public DateTime CreatedAt { get; set; }
}