using FluentValidation;

using Leelite.Core.Validation;

namespace Leelite.DataCategory.Models.CategoryAgg
{
    public class CategoryValidator : Validator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name).NotNull();
        }
    }
}
