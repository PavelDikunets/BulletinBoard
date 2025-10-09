namespace BulletinBoard.Domain.Enums;

/// <summary>
///     Состояние товара.
/// </summary>
public enum Condition
{
    /// <summary>
    ///     Новое.
    /// </summary>
    New,

    /// <summary>
    ///     Б/у.
    /// </summary>
    Used,

    /// <summary>
    ///     Как новое.
    /// </summary>
    LikeNew,

    /// <summary>
    ///     Повреждено.
    /// </summary>
    Damaged,

    /// <summary>
    ///     Не работает.
    /// </summary>
    NotWorking,

    /// <summary>
    ///     На запчасти.
    /// </summary>
    ForParts
}