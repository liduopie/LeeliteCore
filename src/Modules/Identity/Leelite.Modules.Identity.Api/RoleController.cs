using System;
using System.Collections.Generic;
using System.Text;
using Leelite.Framework.WebApi;
using Leelite.Modules.Identity.Dtos.RoleDtos;
using Leelite.Modules.Identity.Interfaces;
using Leelite.Modules.Identity.Models.RoleAgg;
using Microsoft.AspNetCore.Mvc;

namespace Leelite.Modules.Identity.WebApi
{
    [ApiController]
    [Area("Identity")]
    [Route("api/[area]/[controller]")]
    public class RoleController : RESTfulController<Role, int, RoleDto, RoleCreateRequest, RoleUpdateRequest, RoleQueryParameter>
    {
        private readonly IRoleService _service;

        public RoleController(IRoleService service) : base(service)
        {
            _service = service;
        }
    }
}
