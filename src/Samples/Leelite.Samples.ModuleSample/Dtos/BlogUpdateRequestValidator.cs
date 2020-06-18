using FluentValidation;
using Leelite.Commons.Validation;

namespace Leelite.Samples.ModuleSample.Dtos
{
    public class BlogUpdateRequestValidator : Validator<BlogUpdateRequest>
    {
        public BlogUpdateRequestValidator()
        {
            RuleFor(blog => blog.Url).NotNull();
        }
    }
}
