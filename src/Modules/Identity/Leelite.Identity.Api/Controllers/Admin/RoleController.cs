using Leelite.Framework.WebApi;
using Leelite.Identity.Dtos.RoleDtos;
using Leelite.Identity.Interfaces;
using Leelite.Identity.Models.RoleAgg;

using Microsoft.AspNetCore.Mvc;

namespace Leelite.Identity.Api.Controllers.Admin
{
    [Area("Identity")]
    public class RoleController : RESTfulController<Role, int, RoleDto, RoleCreateRequest, RoleUpdateRequest, RoleQueryParameter>
    {
        private readonly IRoleService _service;

        public RoleController(IRoleService service) : base(service)
        {
            _service = service;
        }
    }
}
