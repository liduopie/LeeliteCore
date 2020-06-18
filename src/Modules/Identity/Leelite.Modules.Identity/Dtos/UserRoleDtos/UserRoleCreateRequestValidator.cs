using FluentValidation;
using Leelite.Commons.Validation;

namespace Leelite.Modules.Identity.Dtos.UserRoleDtos
{
    public class UserRoleCreateRequestValidator : Validator<UserRoleCreateRequest>
    {
        public UserRoleCreateRequestValidator()
        {
        }
    }
}
