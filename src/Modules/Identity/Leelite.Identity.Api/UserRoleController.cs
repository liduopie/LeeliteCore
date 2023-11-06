using System.Threading.Tasks;
using FluentValidation;
using Leelite.Framework.WebApi;
using Leelite.Identity.Dtos.UserRoleDtos;
using Leelite.Identity.Interfaces;
using Leelite.Identity.Models.UserRoleAgg;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Leelite.Identity.Api
{
    [ApiController]
    [Area("Identity")]
    [Route("api/[area]/[controller]")]
    public class UserRoleController : RESTfulController<UserRole, UserRoleKey, UserRoleDto, UserRoleCreateRequest, UserRoleUpdateRequest, UserRoleQueryParameter>
    {
        private readonly IUserRoleService _service;

        public UserRoleController(IUserRoleService service) : base(service)
        {
            _service = service;
        }

        // PUT: api/[area]/[controller]/UserId/RoleId
        [HttpPut("{UserId}/{RoleId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public override async Task<ActionResult<UserRoleDto>> Put([FromRoute]UserRoleKey id, [FromBody] UserRoleUpdateRequest updateRequest)
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