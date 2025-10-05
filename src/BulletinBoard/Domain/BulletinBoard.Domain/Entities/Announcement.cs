using BulletinBoard.Domain.Base;

namespace BulletinBoard.Domain.Entities;

/// <summary>
///     Сущность объявления.
/// </summary>
public class Announcement : BaseEntity
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