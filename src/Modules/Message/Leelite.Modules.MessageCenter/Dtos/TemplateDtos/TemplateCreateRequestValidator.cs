using FluentValidation;
using Leelite.Commons.Validation;

namespace Leelite.Modules.MessageCenter.Models.TemplateAgg.Dtos.TemplateDtos
{
    public class TemplateCreateRequestValidator : Validator<TemplateCreateRequest>
    {
        public TemplateCreateRequestValidator()
        {
        }
    }
}
