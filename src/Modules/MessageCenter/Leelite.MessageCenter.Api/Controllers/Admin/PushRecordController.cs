using Leelite.Framework.WebApi;
using Leelite.MessageCenter.Dtos.PushRecordDtos;
using Leelite.MessageCenter.Interfaces;
using Leelite.MessageCenter.Models.PushRecordAgg;

using Microsoft.AspNetCore.Mvc;

namespace Leelite.MessageCenter.Api.Controllers.Admin
{
    [Area("MessageCenter")]
    public class PushRecordController : RESTfulController<PushRecord, long, PushRecordDto, PushRecordCreateRequest, PushRecordUpdateRequest, PushRecordQueryParameter>
    {
        private readonly IPushRecordService _service;

        public PushRecordController(IPushRecordService service) : base(service)
        {
            _service = service;
        }
    }
}