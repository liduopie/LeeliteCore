using System.Threading.Tasks;
using FluentValidation;
using Leelite.Framework.WebApi;
using Leelite.Identity.Dtos.UserLoginDtos;
using Leelite.Identity.Interfaces;
using Leelite.Identity.Models.UserLoginAgg;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Leelite.Identity.WebApi
{
    [ApiController]
    [Area("Identity")]
    [Route("api/[area]/[controller]")]
    public class UserLoginController : RESTfulController<UserLogin, UserLoginKey, UserLoginDto, UserLoginCreateRequest, UserLoginUpdateRequest, UserLoginQueryParameter>
    {
        private readonly IUserLoginService _service;

        public UserLoginController(IUserLoginService service) : base(service)
        {
            _service = service;
        }

        // PUT: api/[area]/[controller]/LoginProvider/ProviderKey
        [HttpPut("{LoginProvider}/{ProviderKey}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public override async Task<ActionResult<UserLoginDto>> Put([FromRoute]UserLoginKey id, [FromBody] UserLoginUpdateRequest updateRequest)
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