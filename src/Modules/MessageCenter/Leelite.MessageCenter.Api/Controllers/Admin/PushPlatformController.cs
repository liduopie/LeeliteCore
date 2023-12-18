using Leelite.Framework.WebApi;
using Leelite.MessageCenter.Dtos.PushPlatformDtos;
using Leelite.MessageCenter.Interfaces;
using Leelite.MessageCenter.Models.PushPlatformAgg;

using Microsoft.AspNetCore.Mvc;

namespace Leelite.MessageCenter.Api.Controllers.Admin
{
    [Area("MessageCenter")]
    public class PushPlatformController : RESTfulController<PushPlatform, int, PushPlatformDto, PushPlatformCreateRequest, PushPlatformUpdateRequest, PushPlatformQueryParameter>
    {
        private readonly IPushPlatformService _service;

        public PushPlatformController(IPushPlatformService service) : base(service)
        {
            _service = service;
        }
    }
}