using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Modules.Identity.Dtos.UserTokenDtos
{
    public class UserTokenCreateRequestValidator : Validator<UserTokenCreateRequest>
    {
        public UserTokenCreateRequestValidator()
        {
        }
    }
}
