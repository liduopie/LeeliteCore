using FluentValidation;
using Leelite.Commons.Validation;

namespace Leelite.Modules.Identity.Dtos.UserTokenDtos
{
    public class UserTokenCreateRequestValidator : Validator<UserTokenCreateRequest>
    {
        public UserTokenCreateRequestValidator()
        {
        }
    }
}
