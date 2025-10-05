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
}