using Leelite.Framework.Service;
using Leelite.Samples.ModuleSample.Dtos;
using Leelite.Samples.ModuleSample.Models.BlogAgg;

namespace Leelite.Samples.ModuleSample.Interfaces
{
    public interface IBlogService : ICrudService<Blog, int, BlogDto, BlogCreateRequest, BlogUpdateRequest, BlogQueryParameter>
    {
        string GetUrl(int id);
    }
}
