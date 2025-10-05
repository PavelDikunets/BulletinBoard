namespace BulletinBoard.Contracts.Errors;

/// <summary>
///     Модель отображения ошибок.
/// </summary>
public class ErrorDto
{
    /// <summary>
    ///     Статус код.
    /// </summary>
    public int StatusCode { get; set; }

    /// <summary>
    ///     Сообщение.
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    ///     Идентификатор трассировки для отладки.
    /// </summary>
    public string TraceId { get; set; }
}