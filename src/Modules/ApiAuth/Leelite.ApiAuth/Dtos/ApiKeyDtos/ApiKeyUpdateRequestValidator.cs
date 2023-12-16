using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.ApiAuth.Dtos.ApiKeyDtos
{
    public class ApiKeyUpdateRequestValidator : Validator<ApiKeyUpdateRequest>
    {
        public ApiKeyUpdateRequestValidator()
        {
        }
    }
}
