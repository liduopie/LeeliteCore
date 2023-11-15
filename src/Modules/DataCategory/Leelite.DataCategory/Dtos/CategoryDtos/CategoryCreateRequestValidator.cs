using FluentValidation;

using Leelite.Core.Validation;

namespace Leelite.DataCategory.Dtos.CategoryDtos
{
    public class CategoryCreateRequestValidator : Validator<CategoryCreateRequest>
    {
        public CategoryCreateRequestValidator()
        {
            RuleFor(c => c.Name).NotNull();
        }
    }
}
