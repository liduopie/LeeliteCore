using Leelite.Framework.Service.Dtos;

namespace Leelite.Identity.Dtos.UserDtos
{
    public class UserChangePasswordRequest : IUpdateRequest<long>
    {
        public long Id { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
