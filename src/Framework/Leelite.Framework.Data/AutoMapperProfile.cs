using AutoMapper;
using Leelite.Framework.Data.Query.Paging;

namespace Leelite.Framework.Data
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap(typeof(PageList<>), typeof(PageList<>));

            // Use CreateMap... Etc.. here (Profile methods are the same as configuration methods)
        }
    }
}
