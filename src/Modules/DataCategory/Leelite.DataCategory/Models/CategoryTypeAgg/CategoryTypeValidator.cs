using FluentValidation;

using Leelite.Core.Validation;

namespace Leelite.DataCategory.Models.CategoryTypeAgg
{
    public class CategoryTypeValidator : Validator<CategoryType>
    {
        public CategoryTypeValidator()
        {
            RuleFor(c => c.Code).NotNull();
            RuleFor(c => c.Name).NotNull();
        }
    }
}
