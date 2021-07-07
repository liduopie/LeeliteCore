using Leelite.Framework.WebApi;
using Leelite.Modules.MessageCenter.Dtos.PlatformDtos;
using Leelite.Modules.MessageCenter.Interfaces;
using Leelite.Modules.MessageCenter.Models.PlatformAgg;
using Microsoft.AspNetCore.Mvc;

namespace Leelite.Modules.MessageCenter.Models.PlatformAgg.WebApi
{
    [ApiController]
    [Area("PlatformAgg")]
    [Route("api/[area]/[controller]")]
    public class PlatformController : RESTfulController<Platform, long, PlatformDto, PlatformCreateRequest, PlatformUpdateRequest, PlatformQueryParameter>
    {
        private readonly IPlatformService _service;

        public PlatformController(IPlatformService service) : base(service)
        {
            _service = service;
        }
    }
}