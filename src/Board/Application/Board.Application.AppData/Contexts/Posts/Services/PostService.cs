using Board.Contracts.Posts;

namespace Board.Application.AppData.Contexts.Posts.Services;

/// <inheritdoc />
public class PostService : IPostService
{
    /// <inheritdoc />
    public async Task<CreatePostDto> AddPost(CreatePostDto model, CancellationToken cancellation)
    {
        if (IsValid(model))
        {
            // Вызов репозитория для сохранения в БД.
            
            // возврат результата.
            return await Task.Run(()=>model, cancellation);
        }

        return new CreatePostDto();
    }

    private bool IsValid(CreatePostDto model)
    { // логика валидации...
        return true;
    }
}