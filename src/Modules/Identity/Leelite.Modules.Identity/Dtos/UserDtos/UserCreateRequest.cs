using System;
using Leelite.Framework.Service.Dtos;
using Leelite.Modules.Identity.Models.UserAgg;

namespace Leelite.Modules.Identity.Dtos.UserDtos
{
    public class UserCreateRequest : IRequest
    {
        public string NickName { get; set; }

        public string RealName { get; set; }

        public string Sex { get; set; }

        public DateTimeOffset Birthday { get; set; }

        public bool IsReal { get; set; }

        public string ProfilePicture { get; set; }

        public string SecurityStamp { get; set; }

        public string ConcurrencyStamp { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public int AccessFailedCount { get; set; }

        public UserLock Lock { get; set; }

        public UserAccount Account { get; set; }

        public UserPassword Password { get; set; }

        public UserPhone Phone { get; set; }

        public UserEmail EmailAddress { get; set; }

        public UserIDCard IDCard { get; set; }

        public UserFacial FacialInfo { get; set; }

        public long CreatorId { get; set; }

        public string Creator { get; set; }

        public DateTime? CreationTime { get; set; }

        public long LastModifierId { get; set; }

        public string Modifier { get; set; }

        public DateTime? LastModificationTime { get; set; }

        public bool IsEnabled { get; set; }

        public bool IsDeleted { get; set; }

    }
}
