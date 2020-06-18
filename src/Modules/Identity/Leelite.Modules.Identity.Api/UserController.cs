using System.Threading.Tasks;
using Leelite.Framework.WebApi;
using Leelite.Modules.Identity.Dtos.UserDtos;
using Leelite.Modules.Identity.Interfaces;
using Leelite.Modules.Identity.Models.UserAgg;
using Microsoft.AspNetCore.Mvc;

namespace Leelite.Modules.Identity.WebApi
{
    [ApiController]
    [Area("Identity")]
    [Route("api/[area]/[controller]")]
    public class UserController : RESTfulController<User, long, UserDto, UserCreateRequest, UserUpdateRequest, UserQueryParameter>
    {
        private readonly IUserService _service;

        public UserController(IUserService service) : base(service)
        {
            _service = service;
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> PostChangePassword([FromBody]UserChangePasswordRequest request)
        {
            // TODO: 需要实现修改密码
            await _service.GetByIdAsync(request.Id);
            return Ok();
        }
    }
}