using FluentValidation;

using Leelite.Core.Validation;

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
