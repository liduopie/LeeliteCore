using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.ApiAuth.Dtos.ApiKeyDtos
{
    public class ApiKeyCreateRequestValidator : Validator<ApiKeyCreateRequest>
    {
        public ApiKeyCreateRequestValidator()
        {
        }
    }
}
