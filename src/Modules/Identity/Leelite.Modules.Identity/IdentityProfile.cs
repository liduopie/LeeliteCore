using AutoMapper;
using Leelite.Modules.Identity.Dtos.RoleClaimDtos;
using Leelite.Modules.Identity.Dtos.RoleDtos;
using Leelite.Modules.Identity.Dtos.UserClaimDtos;
using Leelite.Modules.Identity.Dtos.UserDtos;
using Leelite.Modules.Identity.Dtos.UserFingerprintDtos;
using Leelite.Modules.Identity.Dtos.UserKeyDtos;
using Leelite.Modules.Identity.Dtos.UserLoginDtos;
using Leelite.Modules.Identity.Dtos.UserRoleDtos;
using Leelite.Modules.Identity.Dtos.UserTokenDtos;
using Leelite.Modules.Identity.Models.RoleAgg;
using Leelite.Modules.Identity.Models.RoleClaimAgg;
using Leelite.Modules.Identity.Models.UserAgg;
using Leelite.Modules.Identity.Models.UserClaimAgg;
using Leelite.Modules.Identity.Models.UserFingerprintAgg;
using Leelite.Modules.Identity.Models.UserKeyAgg;
using Leelite.Modules.Identity.Models.UserLoginAgg;
using Leelite.Modules.Identity.Models.UserRoleAgg;
using Leelite.Modules.Identity.Models.UserTokenAgg;

namespace Leelite.Modules.Identity
{
    public class IdentityProfile : Profile
    {
        public IdentityProfile()
        {
            CreateMap<Role, RoleDto>();
            CreateMap<RoleCreateRequest, Role>();
            CreateMap<RoleUpdateRequest, Role>();

            CreateMap<RoleClaim, RoleClaimDto>();
            CreateMap<RoleClaimCreateRequest, RoleClaim>();
            CreateMap<RoleClaimUpdateRequest, RoleClaim>();

            CreateMap<User, UserDto>();
            CreateMap<UserCreateRequest, User>();
            CreateMap<UserUpdateRequest, User>();

            CreateMap<UserClaim, UserClaimDto>();
            CreateMap<UserClaimCreateRequest, UserClaim>();
            CreateMap<UserClaimUpdateRequest, UserClaim>();

            CreateMap<UserFingerprint, UserFingerprintDto>();
            CreateMap<UserFingerprintCreateRequest, UserFingerprint>();
            CreateMap<UserFingerprintUpdateRequest, UserFingerprint>();

            CreateMap<UserKey, UserKeyDto>();
            CreateMap<UserKeyCreateRequest, UserKey>();
            CreateMap<UserKeyUpdateRequest, UserKey>();

            CreateMap<UserLogin, UserLoginDto>();
            CreateMap<UserLoginCreateRequest, UserLogin>();
            CreateMap<UserLoginUpdateRequest, UserLogin>();

            CreateMap<UserRole, UserRoleDto>();
            CreateMap<UserRoleCreateRequest, UserRole>();
            CreateMap<UserRoleUpdateRequest, UserRole>();

            CreateMap<UserToken, UserTokenDto>();
            CreateMap<UserTokenCreateRequest, UserToken>();
            CreateMap<UserTokenUpdateRequest, UserToken>();

        }
    }
}
