using AutoMapper;

using Leelite.ApiAuth.Dtos.ApiKeyDtos;
using Leelite.ApiAuth.Models.ApiKeyAgg;

namespace Leelite.ApiAuth
{
    public class ApiAuthProfile : Profile
    {
        public ApiAuthProfile()
        {
            // ApiKey
            CreateMap<ApiKey, ApiKeyDto>();
            CreateMap<ApiKeyCreateRequest, ApiKey>();
            CreateMap<ApiKeyUpdateRequest, ApiKey>();
        }
    }
}
