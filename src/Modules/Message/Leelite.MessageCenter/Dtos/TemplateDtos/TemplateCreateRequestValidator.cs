using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Modules.MessageCenter.Dtos.TemplateDtos
{
    public class TemplateCreateRequestValidator : Validator<TemplateCreateRequest>
    {
        public TemplateCreateRequestValidator()
        {
        }
    }
}
