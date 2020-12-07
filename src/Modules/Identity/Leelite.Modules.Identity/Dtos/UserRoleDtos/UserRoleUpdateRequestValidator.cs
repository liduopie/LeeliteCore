using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Modules.Identity.Dtos.UserRoleDtos
{
    public class UserRoleUpdateRequestValidator : Validator<UserRoleUpdateRequest>
    {
        public UserRoleUpdateRequestValidator()
        {
        }
    }
}
