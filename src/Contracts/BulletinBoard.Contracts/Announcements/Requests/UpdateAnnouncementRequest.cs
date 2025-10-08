namespace BulletinBoard.Contracts.Announcements.Requests;

/// <summary>
///     Модель обновления объявления.
/// </summary>
public class UpdateAnnouncementRequest
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