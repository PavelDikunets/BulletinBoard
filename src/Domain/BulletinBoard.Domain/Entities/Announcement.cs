using BulletinBoard.Domain.Base;
using BulletinBoard.Domain.Enums;

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

    /// <summary>
    ///     Цена.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    ///     Изображение товара.
    /// </summary>
    public string? Image { get; set; }

    /// <summary>
    ///     Состояние товара.
    /// </summary>
    public Condition Condition { get; set; }

    /// <summary>
    ///     Комплектация товара.
    /// </summary>
    public string? Complectation { get; set; }

    /// <summary>
    ///     Дата последнего обновления.
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}