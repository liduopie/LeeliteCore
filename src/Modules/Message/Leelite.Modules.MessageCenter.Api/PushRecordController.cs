using Leelite.Framework.WebApi;
using Leelite.Modules.MessageCenter.Models.PushRecordAgg.Dtos.PushRecordDtos;
using Leelite.Modules.MessageCenter.Models.PushRecordAgg.Interfaces;
using Leelite.Modules.MessageCenter.Models.PushRecordAgg.Models.PushRecordAgg;
using Microsoft.AspNetCore.Mvc;

namespace Leelite.Modules.MessageCenter.Models.PushRecordAgg.WebApi
{
    [ApiController]
    [Area("PushRecordAgg")]
    [Route("api/[area]/[controller]")]
    public class PushRecordController : RESTfulController<PushRecord, long, PushRecordDto, PushRecordCreateRequest, PushRecordUpdateRequest, PushRecordQueryParameter>
    {
        private readonly IPushRecordService _service;

        public PushRecordController(IPushRecordService service) : base(service)
        {
            _service = service;
        }
    }
}