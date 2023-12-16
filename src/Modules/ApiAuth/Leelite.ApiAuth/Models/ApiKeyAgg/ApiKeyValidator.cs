using FluentValidation;

using Leelite.Core.Validation;

namespace Leelite.ApiAuth.Models.ApiKeyAgg
{
    public class ApiKeyValidator : Validator<ApiKey>
    {
        public ApiKeyValidator()
        {
            RuleFor(c => c.Key).NotNull();
        }
    }
}
