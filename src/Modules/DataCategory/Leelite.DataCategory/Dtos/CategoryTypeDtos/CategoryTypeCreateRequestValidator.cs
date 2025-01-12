using FluentValidation;

using Leelite.Core.Validation;

namespace Leelite.DataCategory.Dtos.CategoryTypeDtos
{
    public class CategoryTypeCreateRequestValidator : Validator<CategoryTypeCreateRequest>
    {
        public CategoryTypeCreateRequestValidator()
        {
            RuleFor(c => c.Code).NotNull();
            RuleFor(c => c.Name).NotNull();
        }
    }
}
