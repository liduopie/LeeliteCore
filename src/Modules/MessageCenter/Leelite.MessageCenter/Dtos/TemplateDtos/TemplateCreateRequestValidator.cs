using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.MessageCenter.Dtos.TemplateDtos
{
    public class TemplateCreateRequestValidator : Validator<TemplateCreateRequest>
    {
        public TemplateCreateRequestValidator()
        {
        }
    }
}
