using BulletinBoard.AppServices.Contexts.Announcements.Services;
using BulletinBoard.Contracts.Announcements.Requests;
using BulletinBoard.Contracts.Announcements.Responses;
using BulletinBoard.Contracts.Errors;
using Microsoft.AspNetCore.Mvc;

namespace BulletinBoard.Hosts.Api.Controllers;

/// <summary>
///     Контроллер для работы с объявлениями.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
public class AnnouncementsController : ControllerBase
{
    private readonly IAnnouncementService _announcementService;

    /// <summary>
    ///     Инициализирует экземпляр <see cref="AnnouncementsController" />.
    /// </summary>
    /// <param name="announcementService">Сервис объявлений.</param>
    public AnnouncementsController(IAnnouncementService announcementService)
    {
        _announcementService = announcementService;
    }

    /// <summary>
    ///     Создает новое объявление.
    /// </summary>
    /// <param name="request">Данные для создания объявления.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Новое объявление.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(AnnouncementResponse), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateAsync([FromBody] CreateAnnouncementRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _announcementService.CreateAsync(request, cancellationToken);

        return CreatedAtRoute("GetById", new { id = response.Id }, response);
    }

    /// <summary>
    ///     Получает объявления по фильтру.
    /// </summary>
    /// <param name="filter">Фильтр.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Коллекция объявлений.</returns>
    [HttpGet("by-filter")]
    public async Task<IActionResult> GetByFilterAsync([FromQuery] AnnouncementFilterRequest filter,
        CancellationToken cancellationToken)
    {
        var responses = await _announcementService.GetByFilterAsync(filter, cancellationToken);

        return Ok(responses);
    }

    /// <summary>
    ///     Получает объявление по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор объявления.</param>
    /// <param name="cancellationToken">Токен отмены операци..</param>
    /// <returns>Объявление.</returns>
    [HttpGet("{id:guid}", Name = "GetById")]
    [ProducesResponseType(typeof(AnnouncementResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await _announcementService.GetByIdAsync(id, cancellationToken);

        return Ok(response);
    }

    /// <summary>
    ///     Обновляет существующее объявление.
    /// </summary>
    /// <param name="id">Идентификатор объявления.</param>
    /// <param name="request">Данные для обновления объявления.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Обновленное объявление.</returns>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(AnnouncementResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateAnnouncementRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _announcementService.UpdateAsync(id, request, cancellationToken);

        return Ok(response);
    }
}