using Leelite.Framework.Service;
using Leelite.Modules.MessageCenter.Models.TemplateAgg.Dtos.TemplateDtos;
using Leelite.Modules.MessageCenter.Models.TemplateAgg.Models.TemplateAgg;

namespace Leelite.Modules.MessageCenter.Models.TemplateAgg.Interfaces
{
    public interface ITemplateService : ICrudService<Template, long, TemplateDto, TemplateCreateRequest, TemplateUpdateRequest, TemplateQueryParameter>
    {
    }
}
