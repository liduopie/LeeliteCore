using Leelite.Framework.Domain.Command;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Framework.Service;
using Leelite.MessageCenter.Dtos.TemplateDtos;
using Leelite.MessageCenter.Interfaces;
using Leelite.MessageCenter.Models.TemplateAgg;
using Leelite.MessageCenter.Repositories;

using Microsoft.Extensions.Logging;

namespace Leelite.MessageCenter.Services
{
    public class TemplateService : CrudService<Template, int, TemplateDto, TemplateCreateRequest, TemplateUpdateRequest, TemplateQueryParameter>, ITemplateService
    {
        public TemplateService(
            ITemplateRepository repository,
            ICommandBus commandBus,
            IUnitOfWork unitOfWork,
            ILogger<TemplateService> logger
            ) : base(repository, commandBus, unitOfWork, logger)
        {
        }
    }
}
