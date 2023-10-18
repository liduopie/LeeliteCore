using Leelite.Framework.WebApi;
using Leelite.Modules.MessageCenter.Dtos.PushPlatformDtos;
using Leelite.Modules.MessageCenter.Interfaces;
using Leelite.Modules.MessageCenter.Models.PlatformAgg;
using Microsoft.AspNetCore.Mvc;

namespace Leelite.Modules.MessageCenter.Models.PlatformAgg.WebApi
{
    [ApiController]
    [Area("Message")]
    [Route("api/[area]/[controller]")]
    public class PlatformController : RESTfulController<PushPlatform, int, PushPlatformDto, PushPlatformCreateRequest, PushPlatformUpdateRequest, PushPlatformQueryParameter>
    {
        private readonly IPushPlatformService _service;

        public PlatformController(IPushPlatformService service) : base(service)
        {
            _service = service;
        }
    }
}