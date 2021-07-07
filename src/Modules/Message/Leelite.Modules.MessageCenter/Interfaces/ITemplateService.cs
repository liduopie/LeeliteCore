using Leelite.Framework.Service;
using Leelite.Modules.MessageCenter.Dtos.TemplateDtos;
using Leelite.Modules.MessageCenter.Models.TemplateAgg;

namespace Leelite.Modules.MessageCenter.Interfaces
{
    public interface ITemplateService : ICrudService<Template, long, TemplateDto, TemplateCreateRequest, TemplateUpdateRequest, TemplateQueryParameter>
    {
    }
}
