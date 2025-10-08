using Microsoft.EntityFrameworkCore;

namespace BulletinBoard.Infrastructure.DataAccess.Repositories;

/// <summary>
///     Базовый репозиторий.
/// </summary>
/// <typeparam name="TEntity">Тип доменной сущности.</typeparam>
/// <typeparam name="TContext">Тип <see cref="DbContext">контекста данных</see>.</typeparam>
public interface IBaseRepository<TEntity, TContext> where TEntity : class where TContext : DbContext
{
    /// <summary>
    ///     Добавляет сущность.
    /// </summary>
    /// <param name="entity">Сущность.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Получает сущность.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Доменная модель.</returns>
    Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Получает последовательность элементов.
    /// </summary>
    /// <returns>Объект постройки запросов к последовательности элементов.</returns>
    IQueryable<TEntity> GetAll();

    /// <summary>
    ///     Обновляет сущность.
    /// </summary>
    /// <param name="entity">Сущность.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Удаляет сущность.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}