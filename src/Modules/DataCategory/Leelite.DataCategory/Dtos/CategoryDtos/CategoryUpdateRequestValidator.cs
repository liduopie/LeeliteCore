using FluentValidation;

using Leelite.Core.Validation;

namespace Leelite.DataCategory.Dtos.CategoryDtos
{
    public class CategoryUpdateRequestValidator : Validator<CategoryUpdateRequest>
    {
        public CategoryUpdateRequestValidator()
        {
            RuleFor(c => c.Name).NotNull();
        }
    }
}
