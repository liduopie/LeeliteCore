using FluentValidation;
using Leelite.Commons.Validation;

namespace Leelite.Modules.Identity.Dtos.UserDtos
{
    public class UserCreateRequestValidator : Validator<UserCreateRequest>
    {
        public UserCreateRequestValidator()
        {
        }
    }
}
