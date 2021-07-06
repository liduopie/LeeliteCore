using Leelite.Framework.Domain.Command;
using Leelite.Framework.Service;
using Leelite.Modules.MessageCenter.Models.TemplateAgg.Dtos.TemplateDtos;
using Leelite.Modules.MessageCenter.Models.TemplateAgg.Interfaces;
using Leelite.Modules.MessageCenter.Models.TemplateAgg.Models.TemplateAgg;
using Leelite.Modules.MessageCenter.Models.TemplateAgg.Repositories;
using Microsoft.Extensions.Logging;

namespace Leelite.Modules.MessageCenter.Models.TemplateAgg.Services
{
    public class TemplateService : CrudService<Template, long, TemplateDto, TemplateCreateRequest, TemplateUpdateRequest, TemplateQueryParameter>, ITemplateService
    {
        public TemplateService(
            ITemplateRepository repository,
            ICommandBus commandBus,
            ILogger<TemplateService> logger
            ) : base(repository, commandBus, logger)
        {
        }
    }
}
