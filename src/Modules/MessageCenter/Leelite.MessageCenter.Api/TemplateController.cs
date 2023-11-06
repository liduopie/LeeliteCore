using Leelite.Framework.WebApi;
using Leelite.MessageCenter.Dtos.TemplateDtos;
using Leelite.MessageCenter.Interfaces;
using Leelite.MessageCenter.Models.TemplateAgg;

using Microsoft.AspNetCore.Mvc;

namespace Leelite.MessageCenter.Api
{
    [ApiController]
    [Area("MessageCenter")]
    [Route("api/[area]/[controller]")]
    public class TemplateController : RESTfulController<Template, int, TemplateDto, TemplateCreateRequest, TemplateUpdateRequest, TemplateQueryParameter>
    {
        private readonly ITemplateService _service;

        public TemplateController(ITemplateService service) : base(service)
        {
            _service = service;
        }
    }
}