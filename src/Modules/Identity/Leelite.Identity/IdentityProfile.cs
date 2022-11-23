using AutoMapper;
using Leelite.Identity.Dtos.RoleClaimDtos;
using Leelite.Identity.Dtos.RoleDtos;
using Leelite.Identity.Dtos.UserClaimDtos;
using Leelite.Identity.Dtos.UserDtos;
using Leelite.Identity.Dtos.UserFingerprintDtos;
using Leelite.Identity.Dtos.UserKeyDtos;
using Leelite.Identity.Dtos.UserLoginDtos;
using Leelite.Identity.Dtos.UserRoleDtos;
using Leelite.Identity.Dtos.UserTokenDtos;
using Leelite.Identity.Models.RoleAgg;
using Leelite.Identity.Models.RoleClaimAgg;
using Leelite.Identity.Models.UserAgg;
using Leelite.Identity.Models.UserClaimAgg;
using Leelite.Identity.Models.UserFingerprintAgg;
using Leelite.Identity.Models.UserKeyAgg;
using Leelite.Identity.Models.UserLoginAgg;
using Leelite.Identity.Models.UserRoleAgg;
using Leelite.Identity.Models.UserTokenAgg;

namespace Leelite.Identity
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
