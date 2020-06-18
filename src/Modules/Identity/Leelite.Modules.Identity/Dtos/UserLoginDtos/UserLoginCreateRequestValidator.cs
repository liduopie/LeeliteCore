using FluentValidation;
using Leelite.Commons.Validation;

namespace Leelite.Modules.Identity.Dtos.UserLoginDtos
{
    public class UserLoginCreateRequestValidator : Validator<UserLoginCreateRequest>
    {
        public UserLoginCreateRequestValidator()
        {
        }
    }
}
