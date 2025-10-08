namespace BulletinBoard.AppServices.Exceptions;

/// <summary>
///     Ошибка отсутствия сущности.
/// </summary>
public class NotFoundException : Exception
{
    public string? Id { get; }
    
    public NotFoundException(string id) : this($"Сущность с идентификатором '{id}' не найдена.", id)
    {
    }

    public NotFoundException(string? message, string id) : base(message)
    {
        Id = id;
    }

    public NotFoundException(string? message, Exception? innerException, string id) : base(message, innerException)
    {
        Id = id;
    }
}