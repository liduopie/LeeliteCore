using System.Threading.Tasks;
using FluentValidation;
using Leelite.Framework.WebApi;
using Leelite.Settings.Dtos.SettingValueDtos;
using Leelite.Settings.Interfaces;
using Leelite.Settings.Models.SettingValueAgg;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Leelite.Settings.Api
{
    [ApiController]
    [Area("Settings")]
    [Route("api/[area]/[controller]")]
    public class SettingValueController : RESTfulController<SettingValue, SettingValueKey, SettingValueDto, SettingValueCreateRequest, SettingValueUpdateRequest, SettingValueQueryParameter>
    {
        private readonly ISettingValueService _service;

        public SettingValueController(ISettingValueService service) : base(service)
        {
            _service = service;
        }


        // PUT: api/[area]/[controller]/LoginProvider/ProviderKey
        [HttpPut("{LoginProvider}/{ProviderKey}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public override async Task<ActionResult<SettingValueDto>> Put([FromRoute]SettingValueKey id, [FromBody] SettingValueUpdateRequest updateRequest)
        {
            if (!id.Equals(updateRequest.Id))
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var dto = await _service.UpdateAsync(updateRequest);

                return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
            }
            catch (ValidationException e)
            {
                // 应该是 422 UnprocessableEntityResult

                return BadRequest(e);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_service.Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest("数据已被更改!");
                    throw;
                }
            }
        }
    }
}