using AutoMapper;
using Leelite.Samples.ModuleSample.Dtos;
using Leelite.Samples.ModuleSample.Models.BlogAgg;

namespace Leelite.Samples.ModuleSample
{
    public class ModuleSampleProfile : Profile
    {
        public ModuleSampleProfile()
        {
            CreateMap<Blog, BlogDto>();
            CreateMap<BlogCreateRequest, Blog>();
            CreateMap<BlogUpdateRequest, Blog>();

            // Use CreateMap... Etc.. here (Profile methods are the same as configuration methods)
        }
    }
}
