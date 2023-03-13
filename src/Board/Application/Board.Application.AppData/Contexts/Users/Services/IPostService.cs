using Board.Contracts.Posts;

namespace Board.Application.AppData.Contexts.Users.Services;

/// <summary>
/// Сервис для работы с объявлениями.
/// </summary>
public interface IPostService
{
    /// <summary>
    /// Создает объявление.
    /// </summary>
    /// <param name="model">Модель создания объявления.</param>
    /// <param name="cancellation">Токен отмены операции.</param>
    /// <returns>Модель объявления.</returns>
    Task<CreatePostDto> AddPost(CreatePostDto model, CancellationToken cancellation);
}