using FluentValidation;
using Leelite.Commons.Validation;

namespace Leelite.Modules.Identity.Dtos.UserTokenDtos
{
    public class UserTokenUpdateRequestValidator : Validator<UserTokenUpdateRequest>
    {
        public UserTokenUpdateRequestValidator()
        {
        }
    }
}
