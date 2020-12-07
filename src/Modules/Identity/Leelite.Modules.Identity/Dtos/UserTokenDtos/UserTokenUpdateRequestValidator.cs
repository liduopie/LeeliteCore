using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Modules.Identity.Dtos.UserTokenDtos
{
    public class UserTokenUpdateRequestValidator : Validator<UserTokenUpdateRequest>
    {
        public UserTokenUpdateRequestValidator()
        {
        }
    }
}
