using System.Threading.Tasks;

using FluentValidation;
using Leelite.Framework.WebApi;
using Leelite.Identity.Dtos.UserTokenDtos;
using Leelite.Identity.Interfaces;
using Leelite.Identity.Models.UserTokenAgg;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Leelite.Identity.Api.Controllers.Admin
{
    [Area("Identity")]
    public class UserTokenController : RESTfulController<UserToken, UserTokenKey, UserTokenDto, UserTokenCreateRequest, UserTokenUpdateRequest, UserTokenQueryParameter>
    {
        private readonly IUserTokenService _service;

        public UserTokenController(IUserTokenService service) : base(service)
        {
            _service = service;
        }

        // PUT: api/[area]/[controller]/UserId/LoginProvider/Name
        [HttpPut("{UserId}/{LoginProvider}/{Name}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public override async Task<ActionResult<UserTokenDto>> Put([FromRoute] UserTokenKey id, [FromBody] UserTokenUpdateRequest updateRequest)
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