using Leelite.Framework.WebApi;
using Leelite.Modules.MessageCenter.Models.TemplateAgg.Dtos.TemplateDtos;
using Leelite.Modules.MessageCenter.Models.TemplateAgg.Interfaces;
using Leelite.Modules.MessageCenter.Models.TemplateAgg.Models.TemplateAgg;
using Microsoft.AspNetCore.Mvc;

namespace Leelite.Modules.MessageCenter.Models.TemplateAgg.WebApi
{
    [ApiController]
    [Area("TemplateAgg")]
    [Route("api/[area]/[controller]")]
    public class TemplateController : RESTfulController<Template, long, TemplateDto, TemplateCreateRequest, TemplateUpdateRequest, TemplateQueryParameter>
    {
        private readonly ITemplateService _service;

        public TemplateController(ITemplateService service) : base(service)
        {
            _service = service;
        }
    }
}