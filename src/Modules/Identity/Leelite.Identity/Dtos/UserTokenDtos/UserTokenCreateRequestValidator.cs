using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Identity.Dtos.UserTokenDtos
{
    public class UserTokenCreateRequestValidator : Validator<UserTokenCreateRequest>
    {
        public UserTokenCreateRequestValidator()
        {
        }
    }
}
