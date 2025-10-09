namespace BulletinBoard.Contracts.Announcements.Requests;

/// <summary>
///     Модель создания объявления.
/// </summary>
public class CreateAnnouncementRequest
{
    /// <summary>
    ///     Заголовок.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    ///     Описание.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    ///     Цена.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    ///     Изображение.
    /// </summary>
    public string? Image { get; set; }

    /// <summary>
    ///     Состояние (например, "New", "Used", "LikeNew", "Damaged", "NotWorking", "ForParts").
    /// </summary>
    public string Condition { get; set; }

    /// <summary>
    ///     Комплектация.
    /// </summary>
    public string? Complectation { get; set; }
}