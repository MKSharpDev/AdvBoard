using AdvBoard.AppServices.Contexts.Advertisement.Service;
using AdvBoard.AppServices.Contexts.Category.Service;
using AdvBoard.Contracts.Advertisement;
using AdvBoard.Contracts.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AdvBoard.Api.Controllers
{

    /// <summary>
    /// Контроллер для работы с объявлениями.
    /// </summary>
    [Route("api/categories")]
    [ApiController]
    [AllowAnonymous]
    public class CategoryController : Controller
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
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
            var result = await _categoryService.GetByIdAsync(id, cancellationToken);
            return StatusCode((int)HttpStatusCode.OK, result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CategoryRequest model, CancellationToken cancellationToken)
        {
            await _categoryService.CreateAsync(model, cancellationToken);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> EditAsync([FromBody] CategoryWithIdRequest model, CancellationToken cancellationToken)
        {
            var result = await _categoryService.UpdatedAsync(model, cancellationToken);

            //Подумать какой статус код надо веррнуть
            return StatusCode((int)HttpStatusCode.OK, result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            await _categoryService.DeletedAsync(id, cancellationToken);

            //Подумать какой статус код надо веррнуть
            return StatusCode((int)HttpStatusCode.OK);
        }
    }
}
