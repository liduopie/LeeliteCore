using FluentValidation;

using Leelite.Core.Validation;

namespace Leelite.Samples.ModuleSample.Dtos
{
    public class BlogCreateRequestValidator : Validator<BlogCreateRequest>
    {
        public BlogCreateRequestValidator()
        {
            RuleFor(blog => blog.Url).NotNull();
        }
    }
}
