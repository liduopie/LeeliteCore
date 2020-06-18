using Leelite.Framework.Domain.Command;
using Leelite.Framework.Domain.Event;
using Leelite.Framework.Service;
using Leelite.Samples.ModuleSample.Dtos;
using Leelite.Samples.ModuleSample.Interfaces;
using Leelite.Samples.ModuleSample.Models.BlogAgg;
using Leelite.Samples.ModuleSample.Repositories;
using Microsoft.Extensions.Logging;

namespace Leelite.Samples.ModuleSample.Services
{
    public class BlogService : CrudService<Blog, int, BlogDto, BlogCreateRequest, BlogUpdateRequest, BlogQueryParameter>,
        IBlogService
    {
        public BlogService(
            IBlogRepository repository,
            ICommandBus commandBus,
            ILogger<BlogService> logger
            ) : base(repository, commandBus, logger)
        {
        }

        public string GetUrl(int id)
        {
            return GetById(id).Url;
        }
    }
}
