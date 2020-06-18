using FluentValidation;
using Leelite.Commons.Validation;

namespace Leelite.Modules.Identity.Dtos.UserKeyDtos
{
    public class UserKeyUpdateRequestValidator : Validator<UserKeyUpdateRequest>
    {
        public UserKeyUpdateRequestValidator()
        {
        }
    }
}
