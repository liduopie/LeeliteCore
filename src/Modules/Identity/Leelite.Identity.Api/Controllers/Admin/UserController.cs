using System.Threading.Tasks;
using Leelite.Framework.WebApi;
using Leelite.Identity.Dtos.UserDtos;
using Leelite.Identity.Interfaces;
using Leelite.Identity.Models.UserAgg;

using Microsoft.AspNetCore.Mvc;

namespace Leelite.Identity.Api.Controllers.Admin
{
    [Area("Identity")]
    public class UserController : RESTfulController<User, long, UserDto, UserCreateRequest, UserUpdateRequest, UserQueryParameter>
    {
        private readonly IUserService _service;

        public UserController(IUserService service) : base(service)
        {
            _service = service;
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> PostChangePassword([FromBody] UserChangePasswordRequest request)
        {
            // TODO: 需要实现修改密码
            await _service.GetByIdAsync(request.Id);
            return Ok();
        }
    }
}