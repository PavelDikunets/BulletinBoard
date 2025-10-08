namespace BulletinBoard.Contracts.Announcements.Requests;

/// <summary>
///     Модель фильтрации объявлений.
/// </summary>
public class AnnouncementFilterRequest
{
    /// <summary>
    ///     Заголовок.
    /// </summary>
    public string? Title { get; set; }
}