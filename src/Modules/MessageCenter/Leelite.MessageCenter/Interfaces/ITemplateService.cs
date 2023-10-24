using Leelite.Framework.Service;
using Leelite.MessageCenter.Dtos.TemplateDtos;
using Leelite.MessageCenter.Models.TemplateAgg;

namespace Leelite.MessageCenter.Interfaces
{
    public interface ITemplateService : ICrudService<Template, int, TemplateDto, TemplateCreateRequest, TemplateUpdateRequest, TemplateQueryParameter>
    {
    }
}
