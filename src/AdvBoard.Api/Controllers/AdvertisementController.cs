using AdvBoard.AppServices.Contexts.Advertisement.Service;
using Microsoft.AspNetCore.Mvc;

namespace AdvBoard.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с объявлениями.
    /// </summary>
    [Route("api/advertisements")]
    [ApiController]
    public class AdvertisementController : Controller
    {

        private readonly IAdvertisemenService _advertisemenService;

        public AdvertisementController(IAdvertisemenService advertisemenService)
        {
            _advertisemenService = advertisemenService;
        }

        /// <summary>
        /// Выполняет поиск объявления по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Модель объявления.</returns>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _advertisemenService.GetByIdAsync(id, cancellationToken));
        }
    }
}
