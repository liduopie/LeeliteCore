using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Modules.MessageCenter.Dtos.TemplateDtos
{
    public class TemplateUpdateRequestValidator : Validator<TemplateUpdateRequest>
    {
        public TemplateUpdateRequestValidator()
        {
        }
    }
}
