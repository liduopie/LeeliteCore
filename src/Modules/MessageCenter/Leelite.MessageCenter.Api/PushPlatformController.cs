using Leelite.Framework.WebApi;
using Leelite.MessageCenter.Dtos.PushPlatformDtos;
using Leelite.MessageCenter.Interfaces;
using Leelite.MessageCenter.Models.PushPlatformAgg;

using Microsoft.AspNetCore.Mvc;

namespace Leelite.MessageCenter.Api
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "manager")]
    [Area("MessageCenter")]
    [Route("api/[area]/[controller]")]
    public class PushPlatformController : RESTfulController<PushPlatform, int, PushPlatformDto, PushPlatformCreateRequest, PushPlatformUpdateRequest, PushPlatformQueryParameter>
    {
        private readonly IPushPlatformService _service;

        public PushPlatformController(IPushPlatformService service) : base(service)
        {
            _service = service;
        }
    }
}