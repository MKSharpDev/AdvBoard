﻿using AdvBoard.AppServices.Contexts.Advertisement.Service;
using AdvBoard.Contracts.Advertisement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Reflection;
using System.Threading;

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
        [Authorize]
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await _advertisemenService.GetByIdAsync(id, cancellationToken);
            return StatusCode((int)HttpStatusCode.OK, result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AdvertRequest model, CancellationToken cancellationToken)
        {
            await _advertisemenService.CreateAsync(model, cancellationToken);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> EditAsync([FromBody] AdverWithIdRequest model, CancellationToken cancellationToken)
        {
            var result = await _advertisemenService.UpdatedAsync(model,cancellationToken);

            //Подумать какой статус код надо веррнуть
            return StatusCode((int)HttpStatusCode.OK, result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            await _advertisemenService.DeletedAsync(id, cancellationToken);

            //Подумать какой статус код надо веррнуть
            return StatusCode((int)HttpStatusCode.OK);
        }
    }
}
