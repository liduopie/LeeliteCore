using FluentValidation;
using Leelite.Commons.Validation;

namespace Leelite.Modules.Identity.Dtos.UserKeyDtos
{
    public class UserKeyCreateRequestValidator : Validator<UserKeyCreateRequest>
    {
        public UserKeyCreateRequestValidator()
        {
        }
    }
}
