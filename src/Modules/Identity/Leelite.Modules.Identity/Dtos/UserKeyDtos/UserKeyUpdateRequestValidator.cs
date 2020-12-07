using FluentValidation;
using Leelite.Core.Validation;

namespace Leelite.Modules.Identity.Dtos.UserKeyDtos
{
    public class UserKeyUpdateRequestValidator : Validator<UserKeyUpdateRequest>
    {
        public UserKeyUpdateRequestValidator()
        {
        }
    }
}
