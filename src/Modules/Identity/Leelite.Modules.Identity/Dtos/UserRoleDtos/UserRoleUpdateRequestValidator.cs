using FluentValidation;
using Leelite.Commons.Validation;

namespace Leelite.Modules.Identity.Dtos.UserRoleDtos
{
    public class UserRoleUpdateRequestValidator : Validator<UserRoleUpdateRequest>
    {
        public UserRoleUpdateRequestValidator()
        {
        }
    }
}
