using FluentValidation;

using Leelite.Core.Validation;

namespace Leelite.DataCategory.Dtos.CategoryTypeDtos
{
    public class CategoryTypeUpdateRequestValidator : Validator<CategoryTypeUpdateRequest>
    {
        public CategoryTypeUpdateRequestValidator()
        {
            RuleFor(c => c.Code).NotNull();
            RuleFor(c => c.Name).NotNull();
        }
    }
}
