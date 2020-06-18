using FluentValidation;
using Leelite.Commons.Validation;

namespace Leelite.Samples.ModuleSample.Models.BlogAgg
{
    public class BlogValidator : Validator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(blog => blog.Url).NotNull();
        }
    }
}
